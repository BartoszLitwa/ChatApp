namespace ChatApp.Core
{
    /// <summary>
    /// Username detatils needed for creating the tables. And the second username for creating the chat message history table 
    /// </summary>
    public class TableApiModel
    {
        #region Public Properties

        /// <summary>
        /// The user usernamethat has started this conversation
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The second User
        /// </summary>
        public string SecondUser { get; set; }

        #endregion
    }
}
