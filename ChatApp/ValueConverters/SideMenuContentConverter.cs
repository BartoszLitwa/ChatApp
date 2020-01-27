using ChatApp.Core;
using System;
using System.Globalization;

namespace ChatApp
{
    /// <summary>
    /// A converter that takes in a <see cref="SideMenuContent"/> and converts it to correct UI element
    /// </summary>
    public class SideMenuContentConverter : BaseValueConverter<SideMenuContentConverter>
    {
        #region Protected Members

        /// <summary>
        /// An instance of the current chat list control
        /// </summary>
        protected ChatListControl mChatListControl = new ChatListControl();

        #endregion

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the side menu type
            var sideMenuType = (SideMenuContent)value;

            // Switch based on type
            switch (sideMenuType)
            {
                    // Chat
                case SideMenuContent.Chat:
                    return mChatListControl;
                    // Contacts
                case SideMenuContent.Contacts:
                    return "Contacts";
                    // Media
                case SideMenuContent.Media:
                    return "Media";
                    // Unknown
                default:
                    return "No UI yet!";
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
