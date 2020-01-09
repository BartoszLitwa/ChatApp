using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatApp.Core
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
            LogOutCommand = new RelayCommand(LogOut);
            ClearUserDataCommand = new RelayCommand(ClearUserData);
            LoadCommand = new RelayCommand(async () => await LoadAsync());

            LogOutButtonText = "Log Out";
        }

        #endregion

        /// <summary>
        /// Close the settings menu
        /// </summary>
        public void Close()
        {
            // Close settings menu
            IoC.Application.SettingsMenuVisible = false;
        }

        /// <summary>
        /// Close the settings menu
        /// </summary>
        public void Open()
        {
            // Close settings menu
            IoC.Application.SettingsMenuVisible = true;
        }

        /// <summary>
        /// Log user Out of the application
        /// </summary>
        public void LogOut()
        {
            // TODO: Confirm the user wants to logout

            // TODO: Clear any user data/cache

            // Clean all application level view models that contain
            // any information about the current user
            ClearUserData();

            // Go to login page
            IoC.Application.GoToPage(ApplicationPage.Login);
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
            var storedCredentials = await IoC.ClientDataStore.GetLoginCredentialsAsync();

            Name = new TextEntryViewModel { Label = "Name", OriginalText = $"{storedCredentials?.FirstName} {storedCredentials?.LastName}" };
            Username = new TextEntryViewModel { Label = "Username", OriginalText = $"{storedCredentials?.Username}" };
            Password = new PasswordEntryViewModel { Label = "Name", FakePassword = $"********" };
            Email = new TextEntryViewModel { Label = "Name", OriginalText = $"{storedCredentials?.Email}" };
        }
    }
}
