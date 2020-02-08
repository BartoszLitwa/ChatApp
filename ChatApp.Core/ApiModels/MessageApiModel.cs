using System;

namespace ChatApp.Core
{
    /// <summary>
    /// The details of the Send Message between 2 users
    /// </summary>
    public class MessageApiModel
    {
        #region Public Properties

        /// <summary>
        /// The number of this message
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The user that sent this message
        /// </summary>
        public string SendBy { get; set; }

        /// <summary>
        /// The user that this message has been sent
        /// </summary>
        public string SendTo { get; set; }

        /// <summary>
        /// The message thas was sent
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Time that this message was sent
        /// </summary>
        public DateTimeOffset MessageSentTime { get; set; }

        /// <summary>
        /// Time that this message was read by the user that has received this message
        /// </summary>
        public DateTimeOffset MessageReadTime { get; set; }

        /// <summary>
        /// A flag indicating if this message contains a image
        /// </summary>
        public bool ImageAttachment { get; set; }

        /// <summary>
        /// A flag indicating if this message contains a image
        /// </summary>
        public string ImageAttachmentURL { get; set; }

        #endregion
    }
}
