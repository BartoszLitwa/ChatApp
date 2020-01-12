using System;

namespace ChatApp
{
    /// <summary>
    /// The design-Time data for a <see cref="ChatMessageListItemDesignModel"/>
    /// </summary>
    public class ChatMessageListItemDesignModel : ChatMessageListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single Instance of the design model
        /// </summary>
        public static ChatMessageListItemDesignModel Instance => new ChatMessageListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatMessageListItemDesignModel()
        {
            Initials = "LM";
            SenderName = "Luke";
            ImageAttachment = new ChatMessageListItemImageAttachmentViewModel
            {
                ThumbnailUrl = "http://anywhere.com",
            };
            Message = "Some design time visual text!";
            ProfilePictureRGB = "ff0000";
            SentByMe = true;
            MessageSentTime = DateTimeOffset.UtcNow;
            MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3));
        }

        #endregion
    }
}
