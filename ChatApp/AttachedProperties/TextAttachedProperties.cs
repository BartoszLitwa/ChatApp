using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    /// <summary>
    /// Focuses (keyboard focus) this element on load
    /// </summary>
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // If we dont have a control, return
            if (!(sender is Control control))
                return;

            // Focus this control once loaded
            control.Loaded += (ss, ee) => control.Focus();
        }

    }

    /// <summary>
    /// Focuses (keyboard focus) this element on load
    /// </summary>
    public class FocusProperty : BaseAttachedProperty<FocusProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // If we dont have a control, return
            if (!(sender is TextBox control))
                return;

            if((bool)e.NewValue)
                // Focus this control
                control.Focus();
        }

    }

    /// <summary>
    /// Focuses (keyboard focus) and sleectes all text in this element if true
    /// </summary>
    public class FocusAndSelectProperty : BaseAttachedProperty<FocusAndSelectProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // If we dont have a textBox control, return
            if (sender is TextBox control)
            {
                if ((bool)e.NewValue)
                {
                    // Focus this control
                    control.Focus();

                    // Select all text
                    control.SelectAll();
                }
            }
            if (sender is PasswordBox password)
            {
                if ((bool)e.NewValue)
                {
                    // Focus this control
                    password.Focus();

                    // Select all text
                    password.SelectAll();
                }
            }
        }
    }
}
