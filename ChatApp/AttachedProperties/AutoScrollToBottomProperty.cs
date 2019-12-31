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
    public class AutoScrollToBottomProperty : BaseAttachedProperty<AutoScrollToBottomProperty, bool>
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
            scroll.ScrollChanged -= Scroll_ScrollChanged;
            scroll.ScrollChanged += Scroll_ScrollChanged;
        }

        private void Scroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scroll = sender as ScrollViewer;

            // If we are close enough to bottom
            if (scroll.ScrollableHeight - scroll.VerticalOffset < 30)
                scroll.ScrollToEnd();
        }

    }
}
