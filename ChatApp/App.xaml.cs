﻿using ChatApp.Relational;
using Dna;
using System.Threading.Tasks;
using System.Windows;
using static ChatApp.DI;
using static Dna.FrameworkDI;

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
                await ClientDataStore.HasCredentialsAsync() ?
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
        }
    }
}
