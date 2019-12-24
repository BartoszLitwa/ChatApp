﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace ChatApp
{
    /// <summary>
    /// The NoFrameHistory attached property for creating a <see cref="Frame"/> that never shows navigation
    /// and keeps the navigation history empty
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool> 
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the frame
            var frame = (sender as Frame);

            // Hide navigation bar
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            // Clear history on naviagte
            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}
