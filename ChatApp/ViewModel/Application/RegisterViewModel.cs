using ChatApp.Core;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using static ChatApp.DI;

namespace ChatApp
{
    /// <summary>
    /// The viemodel for a login screen
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The username of the user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// A flag indicating if the register command is running
        /// </summary>
        public bool RegisterIsRunning { get; set; }

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
        public RegisterViewModel() 
        {
            //Create commands
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async () => await LoginAsync());
        }

        #endregion

        /// <summary>
        /// Attempts to register a new user
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {
            await RunCommandAsync(() => RegisterIsRunning, async () =>
            {
                // Call the server and attempt to register with the provided credentials
                var result = await Dna.WebRequests.PostAsync<ApiResponse<RegisterResultApiModel>>(
                    RouteHelpers.GetAbsoluteRoute(ApiRoutes.Register),
                    new RegisterCredentialsApiModel
                    {
                        Username = Username,
                        Email = Email,
                        Password = (parameter as IHavePassword).SecurePassword.Unsecure()
                    });

                // If the result has an error
                if (await result.HandleErrorIfFailedAsync("Register failed"))
                    // We are done
                    return;

                // Ok succesfully registered and logged in. Get the users data
                var loginResult = result.ServerResponse.Response;

                // Call the server and attempt to create the friend list
                var resultCreateFriendList = await Dna.WebRequests.PostAsync<ApiResponse>(
                    RouteHelpers.GetAbsoluteRoute(ContactsRoutes.CreateFriendList),
                   new TableApiModel
                   {
                       Username = loginResult.Username
                   },
                   bearerToken: loginResult.Token);

                // If the resultCreateFriendList has an error
                if (await resultCreateFriendList.HandleErrorIfFailedAsync("Creating Friend List failed"))
                    // We are done
                    return;

                // Call the server and attempt to create the friend list
                var resultCreateProfileSettings = await Dna.WebRequests.PostAsync<ApiResponse>(
                    RouteHelpers.GetAbsoluteRoute(ContactsRoutes.CreateProfileSettings),
                   new TableApiModel
                   {
                       Username = loginResult.Username
                   },
                   bearerToken: loginResult.Token);

                // If the resultCreateProfileSettings has an error
                if (await resultCreateProfileSettings.HandleErrorIfFailedAsync("Creating Profile Settings failed"))
                    // We are done
                    return;

                // Let the application view model handle what happens
                await ViewModelApplication.HandleSuccessfulLoginAsync(loginResult);
            });
        }

        /// <summary>
        /// Takes the user to the login page
        /// </summary>
        /// <returns></returns>
        public async Task LoginAsync()
        {
            ViewModelApplication.GoToPage(ApplicationPage.Login);

            await Task.Delay(1);
        }
    }
}
