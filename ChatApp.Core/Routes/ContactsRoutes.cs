namespace ChatApp.Core
{
    /// <summary>
    /// The relative routes to all Contacts calls in the server
    /// </summary>
    public static class ContactsRoutes
    {
        /// <summary>
        /// The route to the Create Contacts method
        /// </summary>
        public const string Create = "/api/contacts/create";

        /// <summary>
        /// The route to the Send Message method
        /// </summary>
        public const string SendMessage = "/api/contacts/sendMessage";
    }
}
