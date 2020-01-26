using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp
{
    /// <summary>
    /// The design-Time data for a <see cref="SettingsViewModel"/>
    /// </summary>
    public class SettingsDesignModel : SettingsViewModel
    {
        #region Singleton

        /// <summary>
        /// A single Instance of the design model
        /// </summary>
        public static SettingsDesignModel Instance => new SettingsDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SettingsDesignModel()
        {
            FirstName = new TextEntryViewModel { Label = "First Name", OriginalText = "Bartosz" };
            LastName = new TextEntryViewModel { Label = "Last Name", OriginalText = "Litwa" };
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "CRNYY" };
            Password = new PasswordEntryViewModel { Label = "Password", FakePassword = "********" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "CRNYY@gmail.com" };
        }

        #endregion
    }
}
