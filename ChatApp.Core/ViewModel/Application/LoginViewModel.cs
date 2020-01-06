using Dna;
using System;
using System.IO;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChatApp.Core
{
    /// <summary>
    /// The viemodel for a login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// The command to register
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoginViewModel() 
        {
            //Create commands
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {
            await RunCommandAsync(() => LoginIsRunning, async () =>
            {
                // Call the server and attempt to login
                // TODO: Move all URLs and API routes to static class in core
                var result = await WebRequests.PostAsync<ApiResponse<LoginResultApiModel>>(
                    "https://localhost:5001/api/login",
                    new LoginCredentialsApiModel
                    {
                        UsernameOrEmail = Email,
                        Password = (parameter as IHavePassword).SecurePassword.Unsecure()
                    });

                // If there was no response, bad data or a response with a error message
                if (result == null || result.ServerResponse == null || !result.ServerResponse.Succesful)
                {
                    // Default Error message
                    // TODO: Localize strings
                    var message = "Unknown error from server call";

                    // If we got a resposne from the server
                    if (result?.ServerResponse != null)
                        message = result.ServerResponse.ErrorMessage;
                    // If we have a result but deserialize failed
                    else if(string.IsNullOrWhiteSpace(result?.RawServerResponse))
                        // Set error message
                        message = $"Unexpected response from server. {result.RawServerResponse}";
                    // If we have a result but no server response details at all
                    else if (result != null)
                        // Set message to standard HTTP server response details
                        message = $"Failed to communicate with server. Status code {result.StatusCode}. {result.StatusDescription}";

                    // Display error
                    await IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                    {
                        // TODO: Localize Strings
                        Title = "Login Failed",
                        Message = message
                    });

                    //We are done
                    return;
                }

                // Ok succesfully logged in. Get the users data
                var userData = result.ServerResponse.Response;

                IoC.Settings.Name = new TextEntryViewModel { Label = "Name", OriginalText = $"{userData.FirstName} {userData.LastName}" };
                IoC.Settings.Username = new TextEntryViewModel { Label = "Username", OriginalText = $"{userData.Username}" };
                IoC.Settings.Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
                IoC.Settings.Email = new TextEntryViewModel { Label = "Email", OriginalText = $"{userData.Email}" };

                // Go to Login Page
                IoC.Application.GoToPage(ApplicationPage.Chat);
            });
        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task RegisterAsync()
        {
            IoC.Application.GoToPage(ApplicationPage.Register);

            await Task.Delay(1);
        }
    }
}
