using ChatApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChatApp.DI;
using static ChatApp.Core.CoreDI;

namespace ChatApp
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        #region Private members

        private bool mSettingsMenuVisible;

        #endregion

        #region Public Properties

        /// <summary>
        /// The current Page 
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// The view model to use for the current page when the CurrentPage changes
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        /// <summary>
        /// True if the side menu should be shown
        /// </summary>
        public bool SideMenuVisible { get; set; } = false;

        /// <summary>
        /// True if the settings menu should be shown
        /// </summary>
        public bool SettingsMenuVisible
        {
            get => mSettingsMenuVisible;
            set 
            {
                // If property has not changed
                if (mSettingsMenuVisible == value)
                    // Ignore
                    return;

                // Set the backing field
                mSettingsMenuVisible = value;

                // If the settings menu is now visible
                if (value)
                    // Reload Settings
                    TaskManager.RunAndForget(ViewModelSettings.LoadAsync);
            }
        }

        #endregion

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">The page to go</param>
        /// <param name="viewModel">The view model, if any, to set explicitly to the new page</param>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {
            // Always hide settings page if we are changing pages
            SettingsMenuVisible = false;

            // Set the view model
            CurrentPageViewModel = viewModel;

            // Set the current page
            CurrentPage = page;

            // Fire off a Current Page changed event
            OnPropertyChanged(nameof(CurrentPage));

            // Show side menu or not
            SideMenuVisible = CurrentPage == ApplicationPage.Chat;
        }

        /// <summary>
        /// Handles what happens when we have successfully logged in
        /// </summary>
        /// <param name="loginResult">The result from the successful login</param>
        /// <returns></returns>
        public async Task HandleSuccessfulLoginAsync(UserProfileDetailsApiModel loginResult)
        {
            // Store this in the client data store
            await ClientDataStore.SaveLoginCredentialsAsync(loginResult.ToLoginCredentialsDataModel());

            // Load new settings
            await ViewModelSettings.LoadAsync();

            // Go to Login Page
            ViewModelApplication.GoToPage(ApplicationPage.Chat);
        }
    }
}
