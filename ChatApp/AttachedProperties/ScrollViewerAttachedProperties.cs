using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    /// <summary>
    /// Scroll an items control to the bottom when the data context changes
    /// </summary>
    public class ScrollToBottomOnLoadProperty : BaseAttachedProperty<ScrollToBottomOnLoadProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Dont do it when in design mode
            if (DesignerProperties.GetIsInDesignMode(sender))
                return;

            // If we dont have a ScrollViewer, return
            if (!(sender is ScrollViewer scroll))
                return;

            // Scroll content ot bottm when context changes
            scroll.DataContextChanged -= Scroll_DataContextChanged;
            scroll.DataContextChanged += Scroll_DataContextChanged;
        }

        private void Scroll_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Scroll to bottom
            (sender as ScrollViewer).ScrollToBottom();
        }
    }
}
