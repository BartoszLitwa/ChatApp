namespace ChatApp.Core
{
    /// <summary>
    /// The credentials for an API client log into the server and receive a token back
    /// </summary>
    public class LoginCredentialsApiModel
    {
        #region Public Properties

        /// <summary>
        /// The users username or email
        /// </summary>
        public string UsernameOrEmail { get; set; }

        /// <summary>
        /// The users password
        /// </summary>
        public string Password { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoginCredentialsApiModel()
        {

        }

        #endregion
    }
}
