namespace ChatApp
{
    /// <summary>
    /// The Design-time Details for a message box dialog
    /// </summary>
    public class MessageBoxDialogDesignModel : MessageBoxDialogViewModel
    {
        #region Sigleton

        /// <summary>
        /// A single Instance of the design model
        /// </summary>
        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MessageBoxDialogDesignModel()
        {
            Message = "Design time messages are fun :)";
            OKText = "OK"; 
        }

        #endregion
    }
}
