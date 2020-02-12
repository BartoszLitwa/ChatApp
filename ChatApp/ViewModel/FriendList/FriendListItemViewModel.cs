using System;
using System.Windows.Input;

namespace ChatApp
{
    /// <summary>
    /// A view model for each chat list message thread item in a chat thread
    /// </summary>
    public class FriendListItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The display name of the sender of the message
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The display username of the sender of the message
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The initials to show for the profile backgorund
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// The RGB values (in hex) for the background color of the profile picture
        /// For example #ffffff white
        /// </summary>
        public string ProfilePictureRGB { get; set; }

        /// <summary>
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// The time the message was read or <see cref="DateTimeOffset.MinValue"/> if not read
        /// </summary>
        public DateTimeOffset AddTime { get; set; }

        /// <summary>
        /// True if this message has been read
        /// </summary>
        public bool FriendAdded => AddTime > DateTimeOffset.MinValue;

        /// <summary>
        /// A flag idnicating if this item was added since the first main list of item was created
        /// Used as a flag for animating in
        /// </summary>
        public bool NewItem { get; set; } = false;

        /// <summary>
        /// A flag indicating if the settings pop up is visible
        /// </summary>
        public bool PopupSettingsVisible { get; set; } = false;

        #endregion

        #region Commands

        /// <summary>
        /// Command for opening the Pop up with all options
        /// </summary>
        public ICommand OpenPopUpSettingsCommand { get; set; }

        #endregion

        #region Constrcutor

        /// <summary>
        /// Default Constcutor
        /// </summary>
        public FriendListItemViewModel()
        {
            // Create Commands
            OpenPopUpSettingsCommand = new RelayCommand(OpenPopupSettings);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// When the Popup button is pressed
        /// </summary>
        public void OpenPopupSettings()
        {

        }

        #endregion
    }
}
