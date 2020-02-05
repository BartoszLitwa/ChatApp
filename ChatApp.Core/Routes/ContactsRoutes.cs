namespace ChatApp.Core
{
    /// <summary>
    /// The relative routes to all Contacts calls in the server
    /// </summary>
    public static class ContactsRoutes
    {
        /// <summary>
        /// The route to the Create MessageHistory method
        /// </summary>
        public const string CreateMessageHistory = "/api/contacts/create/MessageHistory";

        /// <summary>
        /// The route to the Create FriendList method
        /// </summary>
        public const string CreateFriendList = "/api/contacts/create/FriendList";

        /// <summary>
        /// The route to the Create ProfileSettings method
        /// </summary>
        public const string CreateProfileSettings = "/api/contacts/create/ProfileSettings";

        /// <summary>
        /// The route to the Send Message method
        /// </summary>
        public const string SendMessage = "/api/contacts/sendMessage";
    }
}
