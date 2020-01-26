﻿namespace ChatApp.Core
{
    /// <summary>
    /// The details to change for a User Profile from an API client call
    /// </summary>
    public class UpdateUserProfileApiModel
    {
        #region Public Properties

        /// <summary>
        /// The new first name, or null to leave unchanged
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The new last name, or null to leave unchanged
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The new email, or null to leave unchanged
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The new Username, or null to leave unchanged
        /// </summary>
        public string Username { get; set; } 

        #endregion
    }
}
