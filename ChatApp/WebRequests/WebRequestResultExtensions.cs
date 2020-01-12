using ChatApp.Core;
using Dna;
using System.Threading.Tasks;
using static ChatApp.DI;

namespace ChatApp
{
    /// <summary>
    /// Extensions method for the <see cref="WebRequestResultExtensions"/> class
    /// </summary>
    public static class WebRequestResultExtensions
    {
        /// <summary>
        /// Checks the web request result for any errors, displaying them if there are any
        /// </summary>
        /// <typeparam name="T">The type of Api response</typeparam>
        /// <param name="result">The response to check</param>
        /// <param name="title">The title of the dialogbox if there was an error</param>
        /// <returns>Return true if there was an error, or false if all is ok</returns>
        public static async Task<bool> DisplayErrorIfFailedAsync<T>(this WebRequestResult<ApiResponse<T>> result, string title)
        {
            // If there was no response, bad data or a response with a error message
            if (result == null || result.ServerResponse == null || !result.ServerResponse.Succesful)
            {
                // Default Error message
                // TODO: Localize strings
                var message = "Unknown error from server call";

                // If we got a resposne from the server
                if (result?.ServerResponse != null)
                    message = result.ServerResponse.ErrorMessage;
                // If we have a result but deserialize failed
                else if (string.IsNullOrWhiteSpace(result?.RawServerResponse))
                    // Set error message
                    message = $"Unexpected response from server. {result.RawServerResponse}";
                // If we have a result but no server response details at all
                else if (result != null)
                    // Set message to standard HTTP server response details
                    message = $"Failed to communicate with server. Status code {result.StatusCode}. {result.StatusDescription}";

                // Display error
                await UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    // TODO: Localize Strings
                    Title = title,
                    Message = message
                });

                // Return we had an error
                return true;
            }
            // Everything was ok
            return false;
        }
    }
}
