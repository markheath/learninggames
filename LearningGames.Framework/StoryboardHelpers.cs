using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Input;
using System.Diagnostics;
using GalaSoft.MvvmLight;

namespace LearningGames.Framework
{
    public static class StoryboardHelpers
    {
        // Storyboard Name exists to stop Visual Studio 2010 from crashing when we try to use the
        // Storyboard attached property
        #region Storyboard Name Property
        public static string GetStoryboardName(DependencyObject target)
        {
            return (string)target.GetValue(StoryboardNameProperty);
        }

        public static void SetStoryboardName(DependencyObject target, string value)
        {
            target.SetValue(StoryboardNameProperty, value);
        }

        public static readonly DependencyProperty StoryboardNameProperty =
            DependencyProperty.RegisterAttached(
                "StoryboardName",
                typeof(string),
                typeof(StoryboardHelpers),
                new UIPropertyMetadata(null, OnStoryboardNameChanged));

        static void OnStoryboardNameChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            if (ViewModelBase.IsInDesignModeStatic)
            {
                return;
            }
            
            string storyboardName = (string)e.NewValue;
            FrameworkElement fe = (FrameworkElement)target;
            var storyboard = fe.TryFindResource(storyboardName) as Storyboard;
            if (storyboard != null)
            {
                var listener = new StoryboardListener(target, storyboard);
                target.SetValue(StoryboardHelpers.StoryboardProperty, storyboard);
                target.SetValue(StoryboardHelpers.StoryboardListenerProperty, listener);
            }
            else
            {
                // "Probably in Cider editor"
            }
        }
        #endregion

        #region Storyboard Attached Property
        public static Storyboard GetStoryboard(DependencyObject target)
        {
            return (Storyboard)target.GetValue(StoryboardProperty);
        }

        public static void SetStoryboard(DependencyObject target, Storyboard value)
        {
            target.SetValue(StoryboardProperty, value);
        }

        public static readonly DependencyProperty StoryboardProperty =
            DependencyProperty.RegisterAttached(
                "Storyboard",
                typeof(Storyboard),
                typeof(StoryboardHelpers),
                new UIPropertyMetadata(null, OnStoryboardChanged));

        static void OnStoryboardChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            Storyboard storyboard = (Storyboard)e.NewValue;
            var listener = new StoryboardListener(target, storyboard);
            target.SetValue(StoryboardHelpers.StoryboardListenerProperty, listener);
        }

        /// <summary>
        /// Attached property to hold a reference to a StoryboardListener object
        /// </summary>
        public static readonly DependencyProperty StoryboardListenerProperty =
            DependencyProperty.RegisterAttached(
                "StoryboardListener",
                typeof(StoryboardListener),
                typeof(StoryboardHelpers),
                new FrameworkPropertyMetadata());
        #endregion

        #region Storyboard Completed Attached Property
        public static ICommand GetCompleted(DependencyObject target)
        {
            return (ICommand)target.GetValue(CompletedProperty);
        }

        public static void SetCompleted(DependencyObject target, ICommand value)
        {
            target.SetValue(CompletedProperty, value);
        }

        public static readonly DependencyProperty CompletedProperty =
            DependencyProperty.RegisterAttached(
                "Completed",
                typeof(ICommand),
                typeof(StoryboardHelpers),
                new UIPropertyMetadata());
        #endregion

        #region Storyboard Starter Attached Property
        public static IEvent GetBeginEvent(DependencyObject target)
        {
            return (IEvent)target.GetValue(BeginEventProperty);
        }

        public static void SetBeginEvent(DependencyObject target, IEvent value)
        {
            target.SetValue(BeginEventProperty, value);
        }

        public static readonly DependencyProperty BeginEventProperty =
            DependencyProperty.RegisterAttached(
                "BeginEvent",
                typeof(IEvent),
                typeof(StoryboardHelpers),
                new UIPropertyMetadata(null, OnBeginEventChanged));

        static void OnBeginEventChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            IEvent eventFirer = (IEvent)e.NewValue;
            if (eventFirer != null)
            {
                var starter = new StoryboardStarter(target, eventFirer);
                // store a reference so we don't get garbage collected
                target.SetValue(StoryboardHelpers.StoryboardStarterProperty, starter);
            }
        }

        /// <summary>
        /// Attached property to hold a reference to a StoryboardStarter instance
        /// </summary>
        public static readonly DependencyProperty StoryboardStarterProperty =
            DependencyProperty.RegisterAttached(
                "StoryboardStarter",
                typeof(StoryboardStarter),
                typeof(StoryboardHelpers),
                new FrameworkPropertyMetadata());
        #endregion
    }

    class StoryboardStarter
    {
        public DependencyObject DependencyObject { get; private set; }

        public StoryboardStarter(DependencyObject dependencyObject, IEvent eventFirer)
        {
            this.DependencyObject = dependencyObject;
            eventFirer.Event += new EventHandler(eventFirer_Event);
        }

        void eventFirer_Event(object sender, EventArgs e)
        {
            Storyboard storyboard = (Storyboard)DependencyObject.GetValue(StoryboardHelpers.StoryboardProperty);
            storyboard.Begin();
        }
    }

    class StoryboardListener
    {
        public DependencyObject DependencyObject { get; private set; }
        public Storyboard Storyboard { get; private set; }

        public StoryboardListener(DependencyObject dependencyObject, Storyboard storyboard)
        {
            this.DependencyObject = dependencyObject;
            this.Storyboard = storyboard;
            this.Storyboard.Completed += new EventHandler(Storyboard_Completed);
        }

        void Storyboard_Completed(object sender, EventArgs e)
        {
            ICommand completedCommand = (ICommand)DependencyObject.GetValue(StoryboardHelpers.CompletedProperty);
            if (completedCommand != null)
            {
                completedCommand.Execute(null);
            }
        }
    }
}
