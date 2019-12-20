using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    /// <summary>
    /// The IsBusy attached property for a anything that wants to flag if the control is busy
    /// </summary>
    public class IsBusyProperty : BaseAttachedProperty<IsBusyProperty, bool> 
    {
    }
}
