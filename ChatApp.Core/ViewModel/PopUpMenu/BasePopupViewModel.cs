using ChatApp.Core;
using System;

namespace ChatApp.Core
{
    /// <summary>
    /// A view model for the <see cref="BubbleContent"/> control
    /// </summary>
    public class BasePopupViewModel : BaseViewModel
    {
        #region Public Properites

        /// <summary>
        /// The background color of the bubble in ARGB value
        /// </summary>
        public string BubbleBackground { get; set; }

        /// <summary>
        /// The Horizontal Alignment of the bubble arrow
        /// </summary>
        public ElementHorizontalAlignment ArrowHorizontalAlignment { get; set; }

        /// <summary>
        /// The Vertical Alignment of the bubble arrow
        /// </summary>
        public ElementVerticalAlignment ArrowVerticalAlignment { get; set; }

        /// <summary>
        /// The content inside of this popup menu
        /// </summary>
        public BaseViewModel Content { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePopupViewModel()
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
