using ChatApp.Core;
using System;
using System.Collections.Generic;

namespace ChatApp.Core
{
    /// <summary>
    /// A view model for the <see cref="BubbleContent"/> control
    /// </summary>
    public class ChatAttachmentPopupMenuViewModel : BasePopupViewModel
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatAttachmentPopupMenuViewModel()
        {
            // Set default values
            // TODO: Move colors into Core and make use of it here
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>(new[]
                {
                    new MenuItemViewModel
                    {
                        Type = MenuItemType.Header,
                        Text = "Attach a file...",
                    },
                    new MenuItemViewModel
                    {
                        Icon = IconType.File,
                        Text = "From computer",
                    },
                    new MenuItemViewModel
                    {
                        Icon = IconType.Picture,
                        Text = "From pictures",
                    },
                })
            };
        }

        #endregion
    }
}
