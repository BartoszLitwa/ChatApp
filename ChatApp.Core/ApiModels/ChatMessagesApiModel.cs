using System.Collections.Generic;

namespace ChatApp.Core
{
    /// <summary>
    /// The whole chat messages send to client
    /// </summary>
    public class ChatMessagesApiModel
    {
        #region Public Properties

        /// <summary>
        /// A list of all messages
        /// </summary>
        public List<MessageApiModel> ChatMessages { get; set; }

        #endregion
    }
}
