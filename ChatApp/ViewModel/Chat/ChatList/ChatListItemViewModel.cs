using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static ChatApp.DI;

namespace ChatApp
{
    /// <summary>
    /// A view model for each chat list item in the overwie chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
        #region Public Properties 

        /// <summary>
        /// The display name of this chat list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The latest message from this chat
        /// </summary>
        public string Message { get; set; }

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
        /// True if there are unread messages in this chat
        /// </summary>
        public bool NewContentAvailable { get; set; }

        /// <summary>
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; } 

        #endregion

        #region Public Commands

        /// <summary>
        /// Opens the current message thread
        /// </summary>
        public ICommand OpenMessageCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatListItemViewModel()
        {
            // Create commands
            OpenMessageCommand = new RelayCommand(OpenMessage);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// 
        /// </summary>
        public void OpenMessage()
        {
            IsSelected = true;

            ViewModelApplication.GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel
            {
                SenderName = Name,
                SenderInitials = Initials,
                SenderProfilePictureRGB = ProfilePictureRGB,

                Items = new ObservableCollection<ChatMessageListItemViewModel>
                {
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "ff00ff",
                        SenderName = "Bartosz",
                        SentByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "0000ff",
                        SenderName = "Parnell",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "ff00ff",
                        SenderName = "Parnell",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "ff00ff",
                        SenderName = "Bartosz",
                        SentByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "0000ff",
                        SenderName = "Parnell",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        ImageAttachment = new ChatMessageListItemImageAttachmentViewModel
                        {
                            ThumbnailUrl = "http://anywhere.com",
                        },
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "ff00ff",
                        SenderName = "Parnell",
                        SentByMe = false,
                    },
                }
            });
        }

        #endregion
    }
}
