using System;
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
                await Task.Delay(500);

                // Ok succesfully logged in. Get the users data
                // TODO: ask server for users info

                // TODO: Remove when the back end server is ready
                IoC.Settings.Name = new TextEntryViewModel { Label = "Name", OriginalText = $"Bartosz Litwa {DateTime.Now.ToLocalTime()}" };
                IoC.Settings.Username = new TextEntryViewModel { Label = "Username", OriginalText = "CRNYY" };
                IoC.Settings.Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
                IoC.Settings.Email = new TextEntryViewModel { Label = "Email", OriginalText = "CRNYY@gmail.com" };

                // IMPORTANT:Never store this in variables like this
                var email = Email;
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();

                // Go to Login Page
                IoC.Application.GoToPage(ApplicationPage.Chat);
            });

            IoC.Application.GoToPage(ApplicationPage.Chat);
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
