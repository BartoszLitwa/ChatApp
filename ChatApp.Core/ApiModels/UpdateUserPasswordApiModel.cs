﻿namespace ChatApp.Core
{
    /// <summary>
    /// The details to change for a User's Password from an API client call
    /// </summary>
    public class UpdateUserPasswordApiModel
    {
        #region Public Properties

        /// <summary>
        /// The users current password
        /// </summary>
        public string CurrentPassword { get; set; }

        /// <summary>
        /// The users new password
        /// </summary>
        public string NewPassword { get; set; }

        #endregion
    }
}
