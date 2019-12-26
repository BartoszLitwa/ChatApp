using ChatApp.Core;
using System;

namespace ChatApp.Core
{
    /// <summary>
    /// A view model for the <see cref="BubbleContent"/> control
    /// </summary>
    public class ChatAttachmentPopupMenuViewModel : BasePopupMenuViewModel
    {
        #region Public Properites



        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatAttachmentPopupMenuViewModel()
        {
            // Set default values
            // TODO: Move colors into Core and make use of it here
            BubbleBackground = "ffffff";
            ArrowHorizontalAlignment = ElementHorizontalAlignment.Left;
            ArrowVerticalAlignment = ElementVerticalAlignment.Bottom;
        }

        #endregion

    }
}
