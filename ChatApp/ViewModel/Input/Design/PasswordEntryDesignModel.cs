using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp
{
    /// <summary>
    /// The design-Time data for a <see cref="PasswordEntryViewModel"/>
    /// </summary>
    public class PasswordEntryDesignModel : PasswordEntryViewModel
    { 
        #region Singleton

        /// <summary>
        /// A single Instance of the design model
        /// </summary>
        public static PasswordEntryDesignModel Instance => new PasswordEntryDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PasswordEntryDesignModel()
        {
            Label = "Password";
            FakePassword = "********";
        }

        #endregion
    }
}
