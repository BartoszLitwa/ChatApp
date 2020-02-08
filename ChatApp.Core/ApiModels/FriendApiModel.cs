using System;

namespace ChatApp.Core
{
    /// <summary>
    /// All details about a Friend added
    /// </summary>
    public class FriendApiModel
    {
        #region Public Properties

        /// <summary>
        /// Username of the adding user
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The user that this message has been sent
        /// </summary>
        public string FriendUsername { get; set; }

        /// <summary>
        /// The message thas was sent
        /// </summary>
        public bool Accepted { get; set; }

        /// <summary>
        /// Time that this message was sent
        /// </summary>
        public DateTimeOffset AddTime { get; set; }

        /// <summary>
        /// Time that this message was read by the user that has received this message
        /// </summary>
        public DateTimeOffset AcceptationAddTime { get; set; }

        #endregion
    }
}
