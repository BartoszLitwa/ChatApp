using System.Diagnostics;
using System.Security;
using System.Windows.Input;

namespace ChatApp.Core
{
    /// <summary>
    /// View Model for a password entry to edit a password
    /// </summary>
    public class PasswordEntryViewModel : BaseViewModel
    {
        #region Public Properites

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The fake password dispaly string
        /// </summary>
        public string FakePassword { get; set; }

        /// <summary>
        /// The fake password hint text
        /// </summary>
        public string CurrentPasswordHintText { get; set; }

        /// <summary>
        /// The new password hint text
        /// </summary>
        public string NewPasswordHintText { get; set; }

        /// <summary>
        /// The confirm password hint text
        /// </summary>
        public string ConfirmPasswordHintText { get; set; }

        /// <summary>
        /// The current saved password
        /// </summary>
        public SecureString CurrentPassword { get; set; }

        /// <summary>
        /// The current non-commit edited password
        /// </summary>
        public SecureString NewPassword { get; set; }

        /// <summary>
        /// The current non-commit edited confirm password
        /// </summary>
        public SecureString ConfirmPassword { get; set; }

        /// <summary>
        /// Indicates if the current text is in edit mode
        /// </summary>
        public bool Editing { get; set; } = false;

        #endregion

        #region Public Commands

        /// <summary>
        /// Puts athe control into edit mode
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// Cancels out of the edit mode
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Commits the edits and saves the value
        /// as well as goes back to non-edit mode
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PasswordEntryViewModel()
        {
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);

            // Set default hints
            // TODO: Replace with localization text
            CurrentPasswordHintText = "Current Password";
            NewPasswordHintText = "New Password";
            ConfirmPasswordHintText = "Confirm Password";
        }

        #endregion

        #region Commands Methods

        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        public void Edit()
        {
            Editing = true;

            // Clear all passwords
            NewPassword = new SecureString();
            ConfirmPassword = new SecureString();
        }

        /// <summary>
        /// Cancels out of the edit mode
        /// </summary>
        public void Cancel()
        {
            Editing = false;

            NewPassword = CurrentPassword;
        }

        /// <summary>
        /// Commits the content and exits out of edit mode
        /// </summary>
        public void Save()
        {
            //TODO: Save content

            // Make sure current password is correct
            var storedPassword = "Testing";

            // Confirm current password is a match
            if (storedPassword != CurrentPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Wrong password!",
                    Message = "Current password is invalid!",
                });

                return;
            }

            // Check if the new and confirm password are the same and are actually a password
            if (NewPassword.Unsecure() != ConfirmPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password mismatch",
                    Message = "The new and confirm password do not macth",
                });

                return;
            }

            if(NewPassword.Unsecure().Length < 1)
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Password too short",
                    Message = "You must enter a password!",
                });

                return;
            }

            // Set the edited password to the current value
            CurrentPassword = new SecureString();
            foreach(var c in NewPassword.Unsecure().ToCharArray())
            {
                CurrentPassword.AppendChar(c);
            }


            Editing = false;

            IoC.UI.ShowMessage(new MessageBoxDialogViewModel
            {
                Title = "Success",
                Message = "Current password has been changed succesfully!",
            });
        }

        #endregion
    }
}
