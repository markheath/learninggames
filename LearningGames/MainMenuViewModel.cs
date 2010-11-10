using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using LearningGames.Framework;
using GalaSoft.MvvmLight.Messaging;

namespace LearningGames
{
    public class MainMenuViewModel : ViewModelBase
    {

        public MainMenuViewModel(IEnumerable<IGame> games)
        {
            this.Games = new List<GameMenuViewModel>();
            foreach (var game in games)
            {
                this.Games.Add(new GameMenuViewModel(game));
            }

        }

        public List<GameMenuViewModel> Games { get; private set; }
    }

    public class GameMenuViewModel : ViewModelBase
    {
        private ICommand gameSelectedCommand;
        public string Name { get { return Game.Name; } }
        public IGame Game { get; private set; }
        
        public ICommand GameSelectedCommand { get { return gameSelectedCommand; } }
        
        public GameMenuViewModel(IGame game)
        {
            this.Game = game;
            this.gameSelectedCommand = new RelayCommand<IGame>(
                (x) => SelectGame(x));
        }

        private void SelectGame(IGame game)
        {
            Messenger.Default.Send<GameSelectedMessage>(new GameSelectedMessage() { Game = game });
        }
    }
}
