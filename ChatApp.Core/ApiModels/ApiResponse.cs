namespace ChatApp.Core
{
    /// <summary>
    /// The response for all Web API calls made
    /// </summary>
    public class ApiResponse<T>
    {
        #region Public Properties

        /// <summary>
        /// Indicates if the API call was succesful
        /// </summary>
        public bool Succesful => ErrorMessage == null;

        /// <summary>
        /// The error message for a failed API call
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The API repsonse object
        /// </summary>
        public T Response { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ApiResponse()
        {

        }

        #endregion
    }
}
