using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatApp
{
    /// <summary>
    /// A base class to run any animation method when a boolean is set to true
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool> where Parent : BaseAttachedProperty<Parent, bool>, new()
    {
        #region Public Properites

        /// <summary>
        /// A flag indicating if this is the first time this property has been load
        /// </summary>
        public bool FirstLoad { get; set; } = true;

        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // Get the framework elemt
            if (!(sender is FrameworkElement element))
                return;

            // Dont fire if the value doesnt change
            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;

            // On first load
            if(FirstLoad)
            {
                // Start off hidden before we decide how to animate
                element.Visibility = Visibility.Hidden;

                // Create a single self-unhookable event
                //for the elements Loaded event
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    // Unhook ourselves
                    element.Loaded -= onLoaded;

                    // Do desired animation
                    DoAnimation(element, (bool)value);

                    //No longer in first load
                    FirstLoad = false;
                };

                // Hook into the Loaded event of the elemt
                element.Loaded += onLoaded;
            }
            else
            {
                // Do desired animation
                DoAnimation(element, (bool)value);
            }
        }

        /// <summary>
        /// The animation method that is fired when the value changes 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        protected virtual void DoAnimation(FrameworkElement element, bool value)
        {
            
        }
    }

    /// <summary>
    /// Animates a framework elemnt sliding it in from the right on show
    /// and sliding out to the right
    /// </summary>
    public class AnimateSlideInFromRightProperty : AnimateBaseProperty<AnimateSlideInFromRightProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInFromRightAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                // Animate out
                await element.SlideAndFadeOutToRightAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Animates a framework elemnt sliding it in from the left on show
    /// and sliding out to the left
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInFromLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                // Animate out
                await element.SlideAndFadeOutToLeftAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Animates a framework elemnt sliding up from the bottom on show
    /// and sliding out to the bottom on hide
    /// </summary>
    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInFromBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                // Animate out
                await element.SlideAndFadeOutToBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Animates a framework elemnt sliding up from the bottom keeping Margin on show
    /// and sliding out to the bottom on hide
    /// </summary>
    public class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInFromBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: true);
            else
                // Animate out
                await element.SlideAndFadeOutToBottomAsync(FirstLoad ? 0 : 0.3f, keepMargin: true);
        }
    }

    /// <summary>
    /// Animates a framework elemnt sliding up from the top on show
    /// and sliding out to the top on hide
    /// </summary>
    public class AnimateSlideInFromTopProperty : AnimateBaseProperty<AnimateSlideInFromTopProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                // Animate in
                await element.SlideAndFadeInFromTopAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
            else
                // Animate out
                await element.SlideAndFadeOutToTopAsync(FirstLoad ? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Animates a framework elemnt fading in on show
    /// and fading out on hide
    /// </summary>
    public class AnimateFadeInProperty : AnimateBaseProperty<AnimateFadeInProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
                // Animate in
                await element.FadeInAsync(FirstLoad ? 0 : 0.3f);
            else
                // Animate out
                await element.FadeOutAsync(FirstLoad ? 0 : 0.3f);
        }
    }
}
