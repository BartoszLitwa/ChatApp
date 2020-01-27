﻿namespace ChatApp.Core
{
    /// <summary>
    /// The relative routes to all Api calls in the server
    /// </summary>
    public static class ApiRoutes
    {
        /// <summary>
        /// The route to the Register Api method
        /// </summary>
        public const string Login = "/api/login";

        /// <summary>
        /// The route to the Register Api method
        /// </summary>
        public const string Register = "/api/register";

        /// <summary>
        /// The route to the VerifyEmail Api method
        /// </summary>
        public const string VerifyEmail = "/api/verify/email/{userId}/{emailToken}";

        /// <summary>
        /// The route to the UpdateUserProfile Api method
        /// </summary>
        public const string UpdateUserProfile = "/api/user/profile/update";

        /// <summary>
        /// The route to the UpdateUserPassword Api method
        /// </summary>
        public const string UpdateUserPassword = "/api/user/password/update";

        /// <summary>
        /// The route to the GetUserProfile Api method
        /// </summary>
        public const string GetUserProfile = "/api/user/profile";
    }
}
