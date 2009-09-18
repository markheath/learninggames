using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;

namespace LearningGames
{
    [Export]
    public class MainMenuViewModel
    {
        public MainMenuViewModel()
        {
        }
        
        [ImportMany(typeof(IGame))]
        public ObservableCollection<IGame> Games { get; set; }
    }
}
