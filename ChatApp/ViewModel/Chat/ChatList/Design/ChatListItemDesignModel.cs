namespace ChatApp
{
    /// <summary>
    /// The design-Time data for a <see cref="ChatListItemViewModel"/>
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single Instance of the design model
        /// </summary>
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "LM";
            Name = "Luke";
            Message = "This new chat app is awesome! I bet it will be fast too";
            ProfilePictureRGB = "ff0000";
        }

        #endregion
    }
}
