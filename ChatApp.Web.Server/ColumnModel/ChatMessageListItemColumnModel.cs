using System;

namespace ChatApp.Web.Server
{
    public class ChatMessageListItemDataModel
    {
        public int Id { get; set; }
        public string SentBy { get; set; }
        public string Message { get; set; }
        public DateTimeOffset MessageSentTime { get; set; }
        public DateTimeOffset MessageReadTime { get; set; }
        public bool ImageAttachment { get; set; }
        public string ImageAttachmentUrl { get; set; }
    }
}