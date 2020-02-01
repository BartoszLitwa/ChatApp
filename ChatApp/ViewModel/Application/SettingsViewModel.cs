using ChatApp.Core;
using Dna;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Input;
using static ChatApp.DI;
using static Dna.FrameworkDI;

namespace ChatApp
{
    /// <summary>
    /// The settings state as a view model
    /// </summary>
    public class SettingsViewModel : BaseViewModel
    {
        #region Private Mambers

        /// <summary>
        /// The text to show while loading
        /// </summary>
        private string mLoadingText = "...";

        /// <summary>
        /// The Password to show while loading
        /// </summary>
        private string mLoadingPassword = "********";

        #endregion

        #region Public Properties

        /// <summary>
        /// The current users First name
        /// </summary>
        public TextEntryViewModel FirstName { get; set; }

        /// <summary>
        /// The current users Last name
        /// </summary>
        public TextEntryViewModel LastName { get; set; }

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

        #region Transactional Properties

        /// <summary>
        /// Indicates if the First Name is currently being saved
        /// </summary>
        public bool FirstNameIsSaving { get; set; }

        /// <summary>
        /// Indicates if the Last Name is currently being saved
        /// </summary>
        public bool LastNameIsSaving { get; set; }

        /// <summary>
        /// Indicates if the Username is currently being saved
        /// </summary>
        public bool UsernameIsSaving { get; set; }

        /// <summary>
        /// Indicates if the Password is currently being saved
        /// </summary>
        public bool PasswordIsSaving { get; set; }

        /// <summary>
        /// Indicates if the Email is currently being saved
        /// </summary>
        public bool EmailIsSaving { get; set; }

        /// <summary>
        /// Indicates if the settings details are currently being loaded
        /// </summary>
        public bool SettingsLoading { get; set; }

        /// <summary>
        /// Indicates if the user is logging out
        /// </summary>
        public bool LoggingOut { get; set; }

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
        /// Saves the current First Name to the server
        /// </summary>
        public ICommand SaveFirstNameCommand { get; set; }

        /// <summary>
        /// Saves the current Last Name to the server
        /// </summary>
        public ICommand SaveLastNameCommand { get; set; }

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
            // Set initial unloaded values
            // Create First Name
            FirstName = new TextEntryViewModel
            {
                Label = "First Name",
                OriginalText = mLoadingText,
                CommitAction = SaveFirstNameAsync
            };
            // Create Last Name
            LastName = new TextEntryViewModel
            {
                Label = "Last Name",
                OriginalText = mLoadingText,
                CommitAction = SaveLastNameAsync
            };
            // Create Username
            Username = new TextEntryViewModel
            {
                Label = "Username",
                OriginalText = mLoadingText,
                CommitAction = SaveUsernameAsync
            };

            // Create Password
            Password = new PasswordEntryViewModel
            {
                Label = "Password",
                FakePassword = mLoadingPassword,
                CommitAction = SavePasswordAsync
            };

            // Create Email
            Email = new TextEntryViewModel
            {
                Label = "Email",
                OriginalText = mLoadingText,
                CommitAction = SaveEmailAsync
            };

            // Set up commands
            CloseCommand = new RelayCommand(Close);
            OpenCommand = new RelayCommand(Open);
            LogOutCommand = new RelayCommand(async () => await LogOutAsync());
            ClearUserDataCommand = new RelayCommand(ClearUserData);
            LoadCommand = new RelayCommand(async () => await LoadAsync());
            SaveFirstNameCommand = new RelayCommand(async () => await SaveFirstNameAsync());
            SaveLastNameCommand = new RelayCommand(async () => await SaveLastNameAsync());
            SaveUsernameCommand = new RelayCommand(async () => await SaveUsernameAsync());
            SavePasswordCommand = new RelayCommand(async () => await SavePasswordAsync());
            SaveEmailCommand = new RelayCommand(async () => await SaveEmailAsync());

            // TODO: Localize strings
            LogOutButtonText = "Log Out";
        }

        #endregion

        #region Public Commands

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
        public async Task LogOutAsync()
        {
            // Lock this command to ignore any other requests while processing
            await RunCommandAsync(() => LoggingOut, async () =>
            {
                // Confirm the user wants to logout
                await UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Log out",
                    Message = "Do you really want to log out?"
                });

                // Clear any user data/cache
                await ClientDataStore.ClearAllLoginCredentialsAsync();

                // Clean all application level view models that contain
                // any information about the current user
                ClearUserData();

                // Go to login page
                ViewModelApplication.GoToPage(ApplicationPage.Login);
            });
        }

        /// <summary>
        /// Clears any data specific to the user
        /// </summary>
        public void ClearUserData()
        {
            // Clear all view models containg users info
            FirstName.OriginalText = mLoadingText;
            LastName.OriginalText = mLoadingText;
            Username.OriginalText = mLoadingText;
            Password.CurrentPassword = null;
            Password.ConfirmPassword = null;
            Password.NewPassword = null;
            Email.OriginalText = mLoadingText;
        }

        /// <summary>
        /// Sets the settings view model properties based on the data in the client data store
        /// </summary>
        public async Task LoadAsync()
        {
            // Lock this command to ignore any other requests while processing
            await RunCommandAsync(() => SettingsLoading, async () =>
            {
                // Get the scoped instance of ClientDataStore
                var scopedClientDataStore = ClientDataStore;

                // Update values from local cache
                await UpdateValuesFromLocalStoreAsync(scopedClientDataStore);

                // Get the locala values from local cache
                var LoginCredentials = await scopedClientDataStore.GetLoginCredentialsAsync();

                // If we don't have a login credetnails or token...
                if (LoginCredentials == null || string.IsNullOrEmpty(LoginCredentials.Token))
                    // Then do nothing more
                    return;

                // Load user profile details from the server
                var result = await WebRequests.PostAsync<ApiResponse<UserProfileDetailsApiModel>>(
                    RouteHelpers.GetAbsoluteRoute(ApiRoutes.GetUserProfile),
                    // Pass the token
                    bearerToken: LoginCredentials.Token);

                // If it was successful...
                if (result.Successful)
                {
                    // TODO: Should we check if the values are diffrent before saving?
                    // Create the data model form the server's response
                    var dataModel = result.ServerResponse.Response.ToLoginCredentialsDataModel();

                    // Re-Add our known token
                    dataModel.Token = LoginCredentials.Token;

                    // Save the new information in the data store
                    await scopedClientDataStore.SaveLoginCredentialsAsync(dataModel);

                    // Update values from local cache
                    await UpdateValuesFromLocalStoreAsync(scopedClientDataStore);
                }
            });
        }

        /// <summary>
        /// Saves the current First Name to the server
        /// </summary>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SaveFirstNameAsync()
        {
            // Lock this command to ignore any other requests while processing
            return await RunCommandAsync(() => FirstNameIsSaving, async () =>
            {
                // Update the First Name value on the server...
                return await UpdateUserCredentialsDetailsAsync(
                    // Display Name
                    "First Name",
                    // Update the first Name
                    (credentials) => credentials.FirstName,
                    // To new Value
                    FirstName.OriginalText,
                    //Set api model
                    (apiModel, value) => apiModel.FirstName = value);
            });
        }

        /// <summary>
        /// Saves the current Last Name to the server
        /// </summary>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SaveLastNameAsync()
        {
            // Lock this command to ignore any other requests while processing
            return await RunCommandAsync(() => LastNameIsSaving, async () =>
            {
                // Update the Last Name value on the server...
                return await UpdateUserCredentialsDetailsAsync(
                    // Display Name
                    "Last Name",
                    // Update the first Name
                    (credentials) => credentials.LastName,
                    // To new Value
                    LastName.OriginalText,
                    //Set api model
                    (apiModel, value) => apiModel.LastName = value);
            });
        }

        /// <summary>
        /// Saves the new Username to the server
        /// </summary>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SaveUsernameAsync()
        {
            // Lock this command to ignore any other requests while processing
            return await RunCommandAsync(() => UsernameIsSaving, async () =>
            {
                // Update the Username value on the server...
                return await UpdateUserCredentialsDetailsAsync(
                    // Display Name
                    "Username",
                    // Update the first Name
                    (credentials) => credentials.Username,
                    // To new Value
                    Username.OriginalText,
                    //Set api model
                    (apiModel, value) => apiModel.Username = value);
            });
        }

        /// <summary>
        /// Saves the new Password to the server
        /// </summary>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SavePasswordAsync()
        {
            // Lock this command to ignore any other requests while processing
            return await RunCommandAsync(() => PasswordIsSaving, async () =>
            {
                // Log It
                Logger.LogDebugSource($"Changing password");

                // Get the current known credentials
                var credentials = await ClientDataStore.GetLoginCredentialsAsync();

                // Make sure the user has entered the same password
                if(Password.NewPassword.Unsecure() != Password.ConfirmPassword.Unsecure())
                {
                    await UI.ShowMessage(new MessageBoxDialogViewModel
                    {
                        // TODO: Localize
                        Title = "Password Mismatch",
                        Message = "New password and confirm password must match!"
                    });

                    return false;
                }

                // Update the server with the new password
                var result = await WebRequests.PostAsync<ApiResponse>(
                    // Set the URL
                    RouteHelpers.GetAbsoluteRoute(ApiRoutes.UpdateUserPassword),
                    // Create the API model
                    new UpdateUserPasswordApiModel
                    {
                        CurrentPassword = Password.CurrentPassword.Unsecure(),
                        NewPassword = Password.NewPassword.Unsecure()
                    },
                    // Pass in The user Token
                    bearerToken: credentials.Token);

                // If the response has the error
                if (await result.HandleErrorIfFailedAsync($"Change Password"))
                {
                    // Log it
                    Logger.LogDebugSource($"Failed to change the Password. {result.ErrorMessage}");

                    // Return false
                    return false;
                }

                // Log it
                Logger.LogDebugSource($"Successfuly changed Password. Saving to local database...");

                // Store the new users credentials to data Store
                await ClientDataStore.SaveLoginCredentialsAsync(credentials);

                // Return Successful
                return true;
            });
        }

        /// <summary>
        /// Saves the new Email to the server
        /// </summary>
        /// <returns>Returns true if successful, false otherwise</returns>
        public async Task<bool> SaveEmailAsync()
        {
            // Lock this command to ignore any other requests while processing
            return await RunCommandAsync(() => EmailIsSaving, async () =>
            {
                // Update the Email value on the server...
                return await UpdateUserCredentialsDetailsAsync(
                    // Display Name
                    "Email",
                    // Update the first Name
                    (credentials) => credentials.Email,
                    // To new Value
                    Email.OriginalText,
                    //Set api model
                    (apiModel, value) => apiModel.Email = value);
            });
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Updates the specific value from the lcient data store for the user profile details
        /// and attempst to update the server to match those details
        /// For Example, updating the First Name of the user.
        /// </summary>
        /// <param name="displayName">The display Name for logginf and display of the property we are updatign</param>
        /// <param name="propertyToUpdate">The property from the <see cref="LoginCredentialsDataModel"/> to be updated</param>
        /// <param name="newValue">The new value to update the property to</param>
        /// <param name="setApiModel">Sets the correct property int the <see cref="UpdateUserProfileApiModel"/> model that this property maps to</param>
        /// <returns></returns>
        private async Task<bool> UpdateUserCredentialsDetailsAsync(string displayName, Expression<Func<LoginCredentialsDataModel, string>> propertyToUpdate, string newValue, Action<UpdateUserProfileApiModel, string> setApiModel)
        {
            // Log it
            Logger.LogDebugSource($"Saving {displayName}");

            // Get the current known credentials
            var credentials = await ClientDataStore.GetLoginCredentialsAsync();

            // Get the property to update from the credentials
            var toUpdate = propertyToUpdate.GetPropertyValue(credentials);

            // Log it
            Logger.LogDebugSource($"{displayName} currently {toUpdate}, updating to {newValue}.");

            // Check if the values are the same
            if (toUpdate == newValue)
            {
                // Log it
                Logger.LogDebugSource($"{displayName} is the same. Ignoring");

                // Return True
                return true;
            }

            // Set the property
            propertyToUpdate.SetPropertyValue(newValue, credentials);

            // Create update details
            var updateApiModel = new UpdateUserProfileApiModel();

            // Ask caller to set appropriate value
            setApiModel(updateApiModel, newValue);

            // Update the server with the details
            var result = await WebRequests.PostAsync<ApiResponse>(
                // Pass the URL
                RouteHelpers.GetAbsoluteRoute(ApiRoutes.UpdateUserProfile),
                // Pass the Api model
                updateApiModel,
                // Pass the JWT token
                bearerToken: credentials.Token);

            // If the response has the error
            if (await result.HandleErrorIfFailedAsync($"Update {displayName}"))
            {
                // Log it
                Logger.LogDebugSource($"Failed to update the {displayName}. {result.ErrorMessage}");

                // Return false
                return false;
            }

            // Log it
            Logger.LogDebugSource($"Successfuly updated {displayName}. Saving to local database...");

            // Store the new users credentials to data Store
            await ClientDataStore.SaveLoginCredentialsAsync(credentials);

            // Return Successful
            return true;
        }

        /// <summary>
        /// Loads the settings from the local data store and binds them
        /// to this viewmodel
        /// </summary>
        /// <returns></returns>
        private async Task UpdateValuesFromLocalStoreAsync(IClientDataStore scopedClientDataStore)
        {
            // Get the stored credentials
            var storedCredentials = await scopedClientDataStore.GetLoginCredentialsAsync();

            // Set First Name
            FirstName.OriginalText = $"{storedCredentials?.FirstName}";

            // Set Last Name
            LastName.OriginalText = $"{storedCredentials?.LastName}";

            // Set Username
            Username.OriginalText = $"{storedCredentials?.Username}";

            // Set email
            Email.OriginalText = $"{storedCredentials?.Email}";
        }

        #endregion
    }
}
