using ChatApp.Relational;
using System.Threading.Tasks;
using System.Windows.Input;
using static ChatApp.DI;

namespace ChatApp
{
    /// <summary>
    /// The settings state as a view model
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The current users name
        /// </summary>
        public TextEntryViewModel Name { get; set; }

        /// <summary>
        /// The current users Username
        /// </summary>
        public TextEntryViewModel Username { get; set; }

        /// <summary>
        /// The current users Password
        /// </summary>
        public PasswordEntryViewModel Password { get; set; }

        /// <summary>
        /// The current users Email
        /// </summary>
        public TextEntryViewModel Email { get; set; }

        /// <summary>
        /// The text for the log out button
        /// </summary>
        public string LogOutButtonText { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command to close the settings menu
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to open the settings menu
        /// </summary>
        public ICommand OpenCommand { get; set; }

        /// <summary>
        /// The command to log out of the account
        /// </summary>
        public ICommand LogOutCommand { get; set; }

        /// <summary>
        /// The command to clear the users data from the view Model
        /// </summary>
        public ICommand ClearUserDataCommand { get; set; }

        /// <summary>
        /// Loads the settings data from the client data store
        /// </summary>
        public ICommand LoadCommand { get; set; }

        /// <summary>
        /// Saves the current name to the server
        /// </summary>
        public ICommand SaveNameCommand { get; set; }

        /// <summary>
        /// Saves the current username to the server
        /// </summary>
        public ICommand SaveUsernameCommand { get; set; }

        /// <summary>
        /// Saves the current username to the server
        /// </summary>
        public ICommand SavePasswordCommand { get; set; }

        /// <summary>
        /// Saves the current email to the server
        /// </summary>
        public ICommand SaveEmailCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SettingsViewModel()
        {
            // Set up commands
            CloseCommand = new RelayCommand(Close);
            OpenCommand = new RelayCommand(Open);
            LogOutCommand = new RelayCommand(LogOutAsync);
            ClearUserDataCommand = new RelayCommand(ClearUserData);
            LoadCommand = new RelayCommand(async () => await LoadAsync());
            SaveNameCommand = new RelayCommand(async () => await SaveNameAsync());
            SaveUsernameCommand = new RelayCommand(async () => await SaveUsernameAsync());
            SavePasswordCommand = new RelayCommand(async () => await SavePasswordAsync());
            SaveEmailCommand = new RelayCommand(async () => await SaveEmailAsync());

            LogOutButtonText = "Log Out";
        }

        #endregion

        /// <summary>
        /// Close the settings menu
        /// </summary>
        public void Close()
        {
            // Close settings menu
            ViewModelApplication.SettingsMenuVisible = false;
        }

        /// <summary>
        /// Close the settings menu
        /// </summary>
        public void Open()
        {
            // Close settings menu
            ViewModelApplication.SettingsMenuVisible = true;
        }

        /// <summary>
        /// Log user Out of the application
        /// </summary>
        public async void LogOutAsync()
        {
            // Confirm the user wants to logout
            await UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Log out",
                Message = "Do you really want to log out?"
            });

            // Clear any user data/cache
            await ClientDataStore.RemoveLoginCredentialsAsync();

            // Clean all application level view models that contain
            // any information about the current user
            ClearUserData();

            // Go to login page
            ViewModelApplication.GoToPage(ApplicationPage.Login);
        }

        /// <summary>
        /// Clears any data specific to the user
        /// </summary>
        public void ClearUserData()
        {
            // Clear all view models containg users info
            Name = null;
            Username = null;
            Password = null;
            Email = null;
        }

        /// <summary>
        /// Sets the settings view model properties based on the data in the client data store
        /// </summary>
        public async Task LoadAsync()
        {
            // Get the stored credentials
            var storedCredentials = await ClientDataStore.GetLoginCredentialsAsync();

            Name = new TextEntryViewModel
            {
                Label = "Name",
                OriginalText = $"{storedCredentials?.FirstName} {storedCredentials?.LastName}",
                CommitAction = SaveNameAsync
            };
            Username = new TextEntryViewModel
            {
                Label = "Username",
                OriginalText = $"{storedCredentials?.Username}",
                CommitAction = SaveUsernameAsync
            };
            Password = new PasswordEntryViewModel
            { 
                Label = "Name",
                FakePassword = $"********",
                CommitAction = SavePasswordAsync
            };
            Email = new TextEntryViewModel
            { 
                Label = "Name",
                OriginalText = $"{storedCredentials?.Email}",
                CommitAction = SaveEmailAsync
            };
        }

        /// <summary>
        /// Saves the new Name to the server
        /// </summary>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SaveNameAsync()
        {
            // TODO: Update with server
            await Task.Delay(3000);

            // Return success
            return true;
        }

        /// <summary>
        /// Saves the new Username to the server
        /// </summary>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SaveUsernameAsync()
        {
            // TODO: Update with server
            await Task.Delay(3000);

            // Return success
            return true;
        }

        /// <summary>
        /// Saves the new Password to the server
        /// </summary>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SavePasswordAsync()
        {
            // TODO: Update with server
            await Task.Delay(3000);

            // Return success
            return true;
        }

        /// <summary>
        /// Saves the new Email to the server
        /// </summary>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SaveEmailAsync()
        {
            // TODO: Update with server
            await Task.Delay(3000);

            // Return success
            return true;
        }
    }
}
