using ChatApp.Relational;
using Dna;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Windows;
using static ChatApp.DI;
using static Dna.FrameworkDI;
using ChatApp.Core;
using System;
using System.Collections.ObjectModel;

namespace ChatApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom startup so we load our IoC immediatly before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            //Let the base application do what it needs
            base.OnStartup(e);

            // Setup the main application
            await ApplicationSetupAsync();

            // Log it
            Logger.LogDebugSource("Application starting");

            // Setup the application view model based on if we are logged in
            ViewModelApplication.GoToPage(
                // If we are logged in...
                await CheckIfCanLoginAsync() ?
                // Go to chat page
                ApplicationPage.Chat :
                // Otherwise, go to login page
                ApplicationPage.Login);

            //Show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures our application ready for use
        /// </summary>
        private async Task ApplicationSetupAsync()
        {
            // Setup the Dna Framework
            Framework.Construct<DefaultFrameworkConstruction>()
                .AddFileLogger()
                .AddClientDataStore()
                .AddChatAppViewModels()
                .AddChatAppClientServices()
                .Build();

            // Ensure the client data store 
            await ClientDataStore.EnsureDataStoreAsync();

            // Load new settings
            await ViewModelSettings.LoadAsync();

            // Monitor for server connection status
            MonitorServerStatus();
        }

        /// <summary>
        /// Monitors the ChatApp website is up, running and reachable
        /// by periodically hitting up
        /// </summary>
        private void MonitorServerStatus()
        {
            // Flag indicating if it is the first check
            // Prevents from concurency of 2 threads accesing the database at the same time
            var FirstLoad = true;

            var httpWatcher = new HttpEndpointChecker(
                // Checking for HomePage ChatApp
                RouteHelpers.GetAbsoluteRoute(WebRoutes.WebpageReachable),
                // Every 10s
                interval: 10000,
                // Pass in the DI Logger
                logger: Framework.Provider.GetService<Microsoft.Extensions.Logging.ILogger>(),
                // On change
                stateChangedCallback: async (result) =>
                {
                    // If the result is the same as before
                    if (ViewModelApplication.ServerReachable == result)
                    {
                        FirstLoad = false;

                        // Do nothing
                        return;
                    }

                    if (FirstLoad)
                        FirstLoad = false;

                    // Update the view model property with the new result
                    ViewModelApplication.ServerReachable = result;

                    // If now is reachable
                    if(ViewModelApplication.ServerReachable && !FirstLoad)
                    {
                        await CheckIfCanLoginAsync();
                    }
                });
        }

        #region Private Helpers

        private async Task<bool> CheckIfCanLoginAsync()
        {
            // Get login credentials
            var Credentials = await ClientDataStore.GetLoginCredentialsAsync();

            // If there isnt any saved user credentials
            if (Credentials == null)
                return false;

            // Call the server and attempt to login with credentials
            var result = await WebRequests.PostAsync<ApiResponse>(
                RouteHelpers.GetAbsoluteRoute(ApiRoutes.CheckToken),
                bearerToken: Credentials.Token);

            if (!result.Successful)
                return false;

            // Change page to chat page
            ViewModelApplication.GoToPage(ApplicationPage.Chat);

            // Load new settings
            await ViewModelSettings.LoadAsync();

            // If successful user could login(has internet access and his token is valid)
            return true;
        }

        #endregion
    }
}
