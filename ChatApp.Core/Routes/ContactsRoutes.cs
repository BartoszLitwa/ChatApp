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
        public const string CreateProfileSettings = "/api/profile/create/ProfileSettings";

        /// <summary>
        /// The route to the Send Message method
        /// </summary>
        public const string SendMessage = "/api/contacts/SendMessage";

        /// <summary>
        /// The route to the Add Friend method
        /// </summary>
        public const string AddFriend = "/api/contacts/AddFriend";

        /// <summary>
        /// The route to the Remove Friend method
        /// </summary>
        public const string RemoveFriend = "/api/contacts/RemoveFriend";

        /// <summary>
        /// The route to the Add Friend method
        /// </summary>
        public const string UpdateProfileSettings = "/api/profile/update/ProfileSettings";
    }
}
