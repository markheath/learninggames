using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace LearningGames
{
    public interface IGame
    {
        Page Gui { get; }
        string Name { get; }
    }
}
