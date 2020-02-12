using System;
using System.Collections.ObjectModel;

namespace ChatApp
{
    /// <summary>
    /// The design-Time data for a <see cref="ChatMessageListDesignModel"/>
    /// </summary>
    public class ChatMessageListDesignModel : ChatMessageListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single Instance of the design model
        /// </summary>
        public static ChatMessageListDesignModel Instance => new ChatMessageListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatMessageListDesignModel()
        {
            SenderName = "Parnell";
            SenderInitials = "PL";
            SenderProfilePictureRGB = "00ff00";

            Items = new ObservableCollection<ChatMessageListItemViewModel> {

                new ChatMessageListItemViewModel
                {
                    SenderName = SenderName,
                    Initials = SenderInitials,
                    Message = "I'm about to wipe this old server. We need to update the old server to Windows 2016",
                    ProfilePictureRGB = SenderProfilePictureRGB,
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false,
                },
                new ChatMessageListItemViewModel
                {
                    SenderName = "Luke",
                    Initials = "LM",
                    Message = "Let me know when you manage to spin up the new 2016 server",
                    ProfilePictureRGB = "00ff00",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true,
                },
                new ChatMessageListItemViewModel
                {
                    SenderName = "Parnell",
                    Initials = "PL",
                    Message = "The new server is up. Go to 192.168.1.1. \r\nUsername is admin, password is P8ssw0rd!",
                    ProfilePictureRGB = "00ff00",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false,
                },
                new ChatMessageListItemViewModel
                {
                    SenderName = "Luke",
                    Initials = "LM",
                    Message = "Thats amazing how good this application is! Its really Fast and nice-looking!",
                    ProfilePictureRGB = "00ff00",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = true,
                },
                new ChatMessageListItemViewModel
                {
                    SenderName = "Parnell",
                    Initials = "PL",
                    Message = "Im really happy that u like my application! That motivates me to keep up the good work!",
                    ProfilePictureRGB = "00ff00",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false,
                },
                new ChatMessageListItemViewModel
                {
                    SenderName = "Parnell",
                    Initials = "PL",
                    Message = "I really appreciate the work u do! Keep up working on it!",
                    ProfilePictureRGB = "00ff00",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = true,
                },
                new ChatMessageListItemViewModel
                {
                    SenderName = "Parnell",
                    Initials = "PL",
                    Message = "Thanks!",
                    ProfilePictureRGB = "00ff00",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false,
                },
            };
        }

        #endregion
    }
}
