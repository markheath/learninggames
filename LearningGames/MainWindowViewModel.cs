using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using LearningGames.Framework;
using GalaSoft.MvvmLight.Messaging;

namespace LearningGames
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ICommand homeCommand;
        private ICommand settingsCommand;
        private ICommand aboutCommand;

        public ICommand HomeCommand { get { return homeCommand; } }
        public ICommand SettingsCommand { get { return settingsCommand; } }
        public ICommand AboutCommand { get { return aboutCommand; } }

        public MainWindowViewModel()
        {            
            this.homeCommand = new RelayCommand(
                () => Home());
            this.settingsCommand = new RelayCommand(
                () => ShowSettings());
            this.aboutCommand = new RelayCommand(
                () => ShowAbout());
        }

        private void Home()
        {
            Messenger.Default.Send<GoHomeMessage>(new GoHomeMessage());
        }

        private void ShowSettings()
        {
            Messenger.Default.Send<ShowSettingsMessage>(new ShowSettingsMessage());
        }

        private void ShowAbout()
        {
        }
    }
}
