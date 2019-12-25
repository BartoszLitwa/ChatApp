using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core
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
            Items = new List<ChatMessageListItemViewModel> {

                new ChatMessageListItemViewModel
                {
                    SenderName = "Parnell",
                    Initials = "PL",
                    Message = "I'm about to wipe this old server. We need to update the old server to Windows 2016",
                    ProfilePictureRGB = "00ff00",
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
            };
        }

        #endregion
    }
}
