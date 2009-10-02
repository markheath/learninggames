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
        private ICommand gameSelectedCommand;

        public MainMenuViewModel()
        {
            this.gameSelectedCommand = new RelayCommand<IGame>( 
                (x) => SelectGame(x) );
        }
        
        [ImportMany(typeof(IGame))]
        public ObservableCollection<IGame> Games { get; set; }

        public ICommand GameSelectedCommand { get { return gameSelectedCommand; } }

        private void SelectGame(IGame game)
        {            
            Messenger.Default.Send<GameSelectedMessage>(new GameSelectedMessage() { Game = game });
        }
    }
}
