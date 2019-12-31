using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    /// <summary>
    /// Match the label width of all text entry controls inside this panel
    /// </summary>
    public class TextEntryWidthMatcherProperty : BaseAttachedProperty<TextEntryWidthMatcherProperty, bool> 
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the panel(grid typically)
            var panel = (sender as Panel);

            // Call SetWidths initially (this also helps design time to work)
            SetWidths(panel);

            // Wait for panel to load
            RoutedEventHandler onLoaded = null;
            onLoaded = (ss, ee) =>
            {
                // UnHook
                panel.Loaded -= onLoaded;

                // Set Widths
                SetWidths(panel);

                // Loop each child
                foreach (FrameworkElement child in panel.Children)
                {
                    // Ignore any non text entry controls
                    if (!(child is TextEntryControl) && !(child is PasswordEntryControl))
                        continue;

                    var Label = child is TextEntryControl ? (child as TextEntryControl).Label : (child as PasswordEntryControl).Label;

                    // Sets its margin to the given value
                    Label.SizeChanged += (sss, eee) =>
                    {
                        // Update Widths
                        SetWidths(panel);
                    };
                }
            };

            // Hook into the loaded event
            panel.Loaded += onLoaded;
        }

        /// <summary>
        /// Update all child text entry controls so their widths match the largest width of the group
        /// </summary>
        /// <param name="panel"> The panel containg the text entry controls</param>
        private void SetWidths(Panel panel)
        {
            // Keep track of the maximum width
            var maxSize = 0d;

            // Loop each child
            foreach (var child in panel.Children)
            {
                // Ignore any non text entry controls
                if (!(child is TextEntryControl) && !(child is PasswordEntryControl))
                    continue;

                var Label = child is TextEntryControl ? (child as TextEntryControl).Label : (child as PasswordEntryControl).Label;

                // Find if this value is larger than the other control
                maxSize = Math.Max(maxSize, Label.RenderSize.Width + Label.Margin.Left + Label.Margin.Right);
            }

            // Create a grid length converter
            var gridLength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());

            // Loop each child
            foreach (var child in panel.Children)
            {
                if (child is TextEntryControl text)
                    text.LabelWidth = gridLength;

                else if (child is PasswordEntryControl pass)
                    pass.LabelWidth = gridLength;
            }
        }
    }
}
