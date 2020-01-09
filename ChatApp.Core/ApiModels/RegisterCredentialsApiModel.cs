﻿namespace ChatApp.Core
{
    /// <summary>
    /// The credentials for an API client register on the server
    /// </summary>
    public class RegisterCredentialsApiModel
    {
        #region Public Properties

        /// <summary>
        /// The users username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The users email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The users first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The users last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The users password
        /// </summary>
        public string Password { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RegisterCredentialsApiModel()
        {

        }

        #endregion
    }
}
