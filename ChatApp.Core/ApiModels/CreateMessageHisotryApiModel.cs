namespace ChatApp.Core
{
    /// <summary>
    /// Usernames needed to create the chat history of messages 
    /// </summary>
    public class CreateMessageHisotryApiModel
    {
        #region Public Properties

        /// <summary>
        /// The user that has started this conversation
        /// </summary>
        public string FirstUser { get; set; }

        /// <summary>
        /// The second User
        /// </summary>
        public string SecondUser { get; set; }

        #endregion
    }
}
