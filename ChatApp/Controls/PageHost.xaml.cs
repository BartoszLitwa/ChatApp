﻿using ChatApp.Core;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace ChatApp
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        #region Dependency Property

        /// <summary>
        /// The current page to show in the page
        /// </summary>
        public BasePage CurrentPage
        {
            get => (BasePage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        /// <summary>
        /// Refisters <see cref="CurrentPage"/> as a depenedency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged)); 

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PageHost()
        {
            InitializeComponent();

            // If we are in DesignMode show the current Page
            // as the dependency property does not fire
            if(DesignerProperties.GetIsInDesignMode(this))
                NewPage.Content = new ApplicationPageValueConverter().Convert(IoC.Application.CurrentPage);

        }

        #endregion

        #region Property Changed events

        /// <summary>
        /// Called when the <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Get the frames
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            // Store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            // Remove current page from new page frame
            newPageFrame.Content = null;

            // MOve the previous page into the old page frame
            oldPageFrame.Content = oldPageContent;

            // Animate out previous page when the loaded event fires
            // right after this call due to moving frames
            if (oldPageContent is BasePage oldPage)
            {
                // Tel old page to animate out
                oldPage.ShouldAnimateOut = true;

                // Once it is done, remove it
                Task.Delay((int)(oldPage.SlideSeconds * 1000)).ContinueWith((t) =>
                {
                    // Jumps back to UI thread and Removes old page
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                });
            }

            // Set the new page content
            newPageFrame.Content = e.NewValue;
        }

        #endregion
    }
}
