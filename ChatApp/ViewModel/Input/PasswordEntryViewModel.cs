﻿using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatApp
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

        /// <summary>
        /// Indicates if the current control is pending an update (in progress)
        /// </summary>
        public bool Working { get; set; }

        /// <summary>
        /// The action to run when saving the text
        /// Returns true if the commit was succesful, or false otherwise
        /// </summary>
        public Func<Task<bool>> CommitAction { get; set; }

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

            // Clear all passwords
            NewPassword = new SecureString();
            ConfirmPassword = new SecureString();
        }

        /// <summary>
        /// Commits the content and exits out of edit mode
        /// </summary>
        public void Save()
        {
            // Store the result of a commit call
            // Defaulting to true (if no CommitAction is declared
            var result = default(bool);

            RunCommandAsync(() => Working, async () =>
            {
                // While working, come out of edit mode
                Editing = false;

                // Try and do the work
                result = CommitAction == null ? true : await CommitAction();
            }).ContinueWith(t =>
            {
                // If we fail
                if (!result)
                {
                    // Go back into edit mode
                    Editing = true;
                }
            });
        }

        #endregion
    }
}
