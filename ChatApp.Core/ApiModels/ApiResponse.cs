namespace ChatApp.Core
{
    /// <summary>
    /// The response for all Web API calls made
    /// </summary>
    public class ApiResponse
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
        public object Response { get; set; }

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

    /// <summary>
    /// The response for all WEB API calls made with a specific type of known response
    /// </summary>
    /// <typeparam name="T">The specific type of the server response</typeparam>
    public class ApiResponse<T> : ApiResponse
    {
        /// <summary>
        /// The api response object as T
        /// </summary>
        public new T Response { get => (T)base.Response; set => base.Response = value; }
    }
}
