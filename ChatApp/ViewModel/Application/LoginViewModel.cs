﻿using ChatApp.Core;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using static ChatApp.DI;

namespace ChatApp
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
                var result = await Dna.WebRequests.PostAsync<ApiResponse<LoginResultApiModel>>(
                    "https://localhost:5001/api/login",
                    new LoginCredentialsApiModel
                    {
                        UsernameOrEmail = Email,
                        Password = (parameter as IHavePassword).SecurePassword.Unsecure()
                    });

                // If the result has an error
                if (await result.DisplayErrorIfFailedAsync("Login failed"))
                    // We are done
                    return;

                // Ok succesfully logged in. Get the users data
                var loginResult = result.ServerResponse.Response;

                // Let the application view model handle what happens
                await ViewModelApplication.HandleSuccessfulLoginAsync(loginResult);
            });
        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task RegisterAsync()
        {
            ViewModelApplication.GoToPage(ApplicationPage.Register);

            await Task.Delay(1);
        }
    }
}