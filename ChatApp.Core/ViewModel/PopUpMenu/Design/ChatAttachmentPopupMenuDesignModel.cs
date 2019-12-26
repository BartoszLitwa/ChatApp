using ChatApp.Core;
using System;

namespace ChatApp.Core
{
    /// <summary>
    /// The design-Time data for a <see cref="ChatListViewModel"/>
    /// </summary>
    public class ChatAttachmentPopupMenuDesignModel : ChatAttachmentPopupMenuViewModel
    {
        #region Singleton

        /// <summary>
        /// A single Instance of the design model
        /// </summary>
        public static ChatAttachmentPopupMenuDesignModel Instance => new ChatAttachmentPopupMenuDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatAttachmentPopupMenuDesignModel()
        {
           
        }

        #endregion
    }
}
