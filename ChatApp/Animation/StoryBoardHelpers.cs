using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace ChatApp
{
    /// <summary>
    /// Animation helpers for <see cref="StoryBoard"/>
    /// </summary>
    public static class StoryBoardHelpers
    {
        /// <summary>
        /// Adds a slide from right animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="deceleration">The rate of decelartion</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float seconds, double offset, float deceleration = 0.9f)
        {
            // Create the margin animate from right
            var Animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = deceleration,
            };

            // Set the target property name
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));

            // Add this to the storyboard
            storyboard.Children.Add(Animation);
        }

        /// <summary>
        /// Adds a slide to left animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="deceleration">The rate of decelartion</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float seconds, double offset, float deceleration = 0.9f)
        {
            // Create the margin animate from right
            var Animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = deceleration,
            };

            // Set the target property name
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Margin"));

            // Add this to the storyboard
            storyboard.Children.Add(Animation);
        }

        /// <summary>
        /// Adds a fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            // Create the margin animate from right
            var Animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1,
            };

            // Set the target property name
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Opacity"));

            // Add this to the storyboard
            storyboard.Children.Add(Animation);
        }

        /// <summary>
        /// Adds a fade out animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            // Create the margin animate from right
            var Animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0,
            };

            // Set the target property name
            Storyboard.SetTargetProperty(Animation, new PropertyPath("Opacity"));

            // Add this to the storyboard
            storyboard.Children.Add(Animation);
        }
    }
}
