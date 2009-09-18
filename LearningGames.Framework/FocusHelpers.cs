using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LearningGames.Framework
{
    public static class FocusHelpers
    {
        public static IEvent GetFocusEvent(DependencyObject target)
        {
            return (IEvent)target.GetValue(FocusEventProperty);
        }

        public static void SetFocusEvent(DependencyObject target, IEvent value)
        {
            target.SetValue(FocusEventProperty, value);
        }

        public static readonly DependencyProperty FocusEventProperty =
            DependencyProperty.RegisterAttached(
                "FocusEvent",
                typeof(IEvent),
                typeof(FocusHelpers),
                new UIPropertyMetadata(null, OnFocusEventChanged));

        static void OnFocusEventChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            IEvent eventFirer = (IEvent)e.NewValue;
            if (eventFirer != null)
            {
                var starter = new FocusSetter(target, eventFirer);
                target.SetValue(FocusHelpers.FocusSetterProperty, starter);
            }
        }

        public static readonly DependencyProperty FocusSetterProperty =
             DependencyProperty.RegisterAttached(
                "FocusSetter",
                typeof(FocusSetter),
                typeof(FocusHelpers),
                new FrameworkPropertyMetadata());
    }

    class FocusSetter
    {
        public DependencyObject DependencyObject { get; private set; }

        public FocusSetter(DependencyObject dependencyObject, IEvent eventFirer)
        {
            this.DependencyObject = dependencyObject;
            eventFirer.Event += new EventHandler(eventFirer_Event);
        }

        void eventFirer_Event(object sender, EventArgs e)
        {
            FrameworkElement frameworkElement = (FrameworkElement)DependencyObject;
            frameworkElement.Focus();
        }
    }
}
