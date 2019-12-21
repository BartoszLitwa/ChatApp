using System;
using System.Windows.Input;

namespace ChatApp.Core
{
    public class RelayParameterizedCommand : ICommand
    {
        #region Private Members

        //A Action to run
        private Action<object> mAction;

        #endregion

        #region Public events
        /// <summary>
        /// The event thats fired when <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender,e) => {};
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public RelayParameterizedCommand(Action<object> action)
        {
            mAction = action;
        }
        #endregion

        #region Command Methods
        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter) { return true; }

        /// <summary>
        /// Execute the command Action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            mAction(parameter);
        }
        #endregion
    }
}
