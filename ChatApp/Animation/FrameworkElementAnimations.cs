﻿using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace ChatApp
{
    /// <summary>
    /// Helpers to animate framework elements in specific ways
    /// </summary>
    public static class FrameworkElementAnimations
    {
        #region Slide In From Right

        /// <summary>
        /// Slides an element in from the right
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <param name="width">The animation width to animate to. If not specified the elements width is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideFromRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            // Add fade in animation
            sb.AddFadeIn(seconds);

            // Start animating
            sb.Begin(element);

            // Make page visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element out to the right
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <param name="height">The animation width to animate to. If not specified the elements width is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideToRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            // Add fade in animation
            sb.AddFadeOut(seconds);

            // Start animating
            sb.Begin(element);

            // Make page visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        #endregion

        #region Slide in From Left

        /// <summary>
        /// Slides an element in from the right
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <param name="width">The animation width to animate to. If not specified the elements width is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideFromLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            // Add fade in animation
            sb.AddFadeIn(seconds);

            // Start animating
            sb.Begin(element);

            // Make page visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element out to the left
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <param name="width">The animation width to animate to. If not specified the elements width is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int width = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideToLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);

            // Add fade in animation
            sb.AddFadeOut(seconds);

            // Start animating
            sb.Begin(element);

            // Make page visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        #endregion

        #region Slide in From Bottom

        /// <summary>
        /// Slides an element in from bottom
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <param name="height">The animation height to animate to. If not specified the elements height is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromBottomAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from bottom animation
            sb.AddSlideFromBottom(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);

            // Add fade in animation
            sb.AddFadeIn(seconds);

            // Start animating
            sb.Begin(element);

            // Make page visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element out to the bottom
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <param name="height">The animation height to animate to. If not specified the elements height is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToBottomAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide to bottom animation
            sb.AddSlideToBottom(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);

            // Add fade in animation
            sb.AddFadeOut(seconds);

            // Start animating
            sb.Begin(element);

            // Make page visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        #endregion

        #region Slide in From Top

        /// <summary>
        /// Slides an element in from top
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <param name="height">The animation height to animate to. If not specified the elements height is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromTopAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from top animation
            sb.AddSlideFromTop(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);

            // Add fade in animation
            sb.AddFadeIn(seconds);

            // Start animating
            sb.Begin(element);

            // Make page visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Slides an element out to the top
        /// </summary>
        /// <param name="element">The element to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="keepMargin">Whether to keep the element at the same width during animation</param>
        /// <param name="height">The animation height to animate to. If not specified the elements height is used</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToTopAsync(this FrameworkElement element, float seconds = 0.3f, bool keepMargin = true, int height = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide to top animation
            sb.AddSlideToTop(seconds, height == 0 ? element.ActualHeight : height, keepMargin: keepMargin);

            // Add fade in animation
            sb.AddFadeOut(seconds);

            // Start animating
            sb.Begin(element);

            // Make page visible
            element.Visibility = Visibility.Visible;

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        #endregion

    }
}