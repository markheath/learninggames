using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace LearningGames.Framework
{
    public interface INavigationService
    {
        void NavigateTo(object target);
    }

#if !SILVERLIGHT
    public class NavigationAdapter : INavigationService
    {
        private Frame frame;
        
        public NavigationAdapter(Frame frame)
        {
            this.frame = frame;
        }        

        public void NavigateTo(object target)
        {
            frame.Navigate(target);
        }
    }
#else
    public class NavigationAdapter : INavigationService
    {
        private ContentPresenter frame;

        public NavigationAdapter(ContentPresenter frame)
        {
            this.frame = frame;
        }

        public void NavigateTo(object target)
        {
            frame.Content = target;
        }
    }
#endif
}
