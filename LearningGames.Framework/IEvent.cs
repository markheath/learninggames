using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Framework
{
    public interface IEvent
    {
        event EventHandler Event;
    }

    public class EventFirer : IEvent
    {
        public void Fire(object sender)
        {
            if (Event != null)
            {
                Event(sender, EventArgs.Empty);
            }
        }

        public event EventHandler Event;
    }
}
