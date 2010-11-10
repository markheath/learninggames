using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace LearningGames
{
    public interface IGame
    {
        UserControl Gui { get; }
        UserControl SettingsGui { get; }
        string Name { get; }
    }
}
