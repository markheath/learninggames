using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LearningGames.Framework;
using GalaSoft.MvvmLight.Messaging;

namespace LearningGames
{
    class NavigationManager
    {
        private INavigationService navigationService;
        private IGame currentGame;
        private object home;

        public NavigationManager(INavigationService navigationService, object home)
        {
            this.navigationService = navigationService;
            this.home = home;
            Messenger.Default.Register<GameSelectedMessage>(this,(g)=>OnGameSelected(g));
            Messenger.Default.Register<GoHomeMessage>(this, (m) => OnGoHomeMessage(m));
            Messenger.Default.Register<NavigateMessage>(this, (m) => OnNavigate(m));
            Messenger.Default.Register<ShowSettingsMessage>(this, (m) => OnShowSettingsMessage(m));
        }

        private void OnNavigate(NavigateMessage message)
        {
            navigationService.NavigateTo(message.Target);
        }

        private void OnGameSelected(GameSelectedMessage gameSelectedMessage)
        {
            currentGame = gameSelectedMessage.Game;
            navigationService.NavigateTo(gameSelectedMessage.Game.Gui);
        }

        private void OnGoHomeMessage(GoHomeMessage message)
        {
            navigationService.NavigateTo(home);
        }

        private void OnShowSettingsMessage(ShowSettingsMessage message)
        {
            if (currentGame == null)
            {
                navigationService.NavigateTo(currentGame.SettingsGui);
            }
        }
    }
}
