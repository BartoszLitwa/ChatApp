namespace ChatApp.Core
{
    /// <summary>
    /// The relative routes to all Non-Api calls in the server
    /// </summary>
    public static class WebRoutes
    {
        /// <summary>
        /// The route to the Login method
        /// </summary>
        public const string Login = "/login";

        /// <summary>
        /// The route to the LogOut method
        /// </summary>
        public const string LogOut = "/logout";

        /// <summary>
        /// The route to the CreateUser method
        /// </summary>
        public const string CreateUser = "/user/create";

        /// <summary>
        /// The route to the Private method
        /// </summary>
        public const string Private = "/user/private";
    }
}
