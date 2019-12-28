using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    /// <summary>
    /// The NoFrameHistory attached property for creating a <see cref="Frame"/> that never shows navigation
    /// and keeps the navigation history empty
    /// </summary>
    public class PanelChildMarginProperty : BaseAttachedProperty<PanelChildMarginProperty, string> 
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the panel(grid typically)
            var panel = (sender as Panel);

            // Wait for panel to load
            panel.Loaded += (ss, ee) =>
            {
                // Loop each child
                foreach (FrameworkElement child in panel.Children)
                {
                    // Sets its margin to the given value
                    child.Margin = (Thickness)new ThicknessConverter().ConvertFromString(e.NewValue as string);
                }
            };
        }
    }
}
