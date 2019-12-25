using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core
{
    /// <summary>
    /// The application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// The current Page 
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Chat;

        /// <summary>
        /// True if the side menu is viisble
        /// </summary>
        public bool SIdeMenuVisible { get; set; } = true;

        /// <summary>
        /// Navigates to the specified page
        /// </summary>
        /// <param name="page">The page to go</param>
        public void GoToPage(ApplicationPage page)
        {
            // Set the current page
            CurrentPage = page;

            // Show side menu or not
            SIdeMenuVisible = CurrentPage == ApplicationPage.Chat;
        }
    }
}
