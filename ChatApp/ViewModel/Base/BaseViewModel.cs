using PropertyChanged;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ChatApp.Core;

namespace ChatApp
{
    /// <summary>
    /// A base viewmodel that fires proprtyChanged events as needed
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes it value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Command Helpers

        /// <summary>
        /// Runs a command if the updating flag is not set
        /// If the flag is true (the fucntion is already running) then the action is not run
        /// If the flag is false (indicating no running function) then the action is run
        /// Once the action is finished if it was run, then the flag is reset to false
        /// </summary>
        /// <param name="updatingFlag">The boolean property flag if the command is already running</param>
        /// <param name="action">The action to run if the command is not already running</param>
        /// <returns></returns>
        protected async Task RunCommandAsync(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            //Checking if the flag property is true (meaning the function is already running
            if (updatingFlag.GetPropertyValue<bool>())
                return;

            //Set the property flag to true to indicate we are running
            updatingFlag.SetPropertyValue(true);

            try
            {
                //Run the passed in action
                await action();
            }
            finally
            {
                // Set the property flag back to false now its finished
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion
    }
}