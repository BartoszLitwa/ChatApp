using System;

namespace ChatApp.Core
{
    /// <summary>
    /// Username detatils needed for creating the tables. And the second username for creating the chat message history table 
    /// </summary>
    public class ProfileSettingsApiModel
    {
        #region Public Properties

        /// <summary>
        /// Settings and Profile of this user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The current theme of the application (dark theme etc)
        /// </summary>
        public int Theme { get; set; }

        /// <summary>
        /// The current status of the user (online, offline etc.)
        /// </summary>
        public int CurrentStatus { get; set; }

        /// <summary>
        /// Time that this message was sent
        /// </summary>
        public DateTimeOffset LastLoggedIn { get; set; }

        /// <summary>
        /// Time that this message was read by the user that has received this message
        /// </summary>
        public DateTimeOffset FirstLoggedIn { get; set; }

        #endregion
    }
}
