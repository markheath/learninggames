using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using LearningGames;
using System.Windows.Controls;
using LearningGames.Framework;

namespace LearningGames.Numbers
{
    [Export(typeof(IGame))]
    public class NumbersGame : IGame
    {
        Page gui;
        Page settingsGui;

        public NumbersGame()
        {

        }

        public Page Gui
        {
            get { if (gui == null) CreateGui(); return gui; }
        }

        public Page SettingsGui
        {
            get { if (settingsGui == null) CreateSettingsGui(); return settingsGui; }
        }


        private void CreateGui()
        {
            var page = new NewGame();
            page.DataContext = new NewGameViewModel();
            gui = page;
        }

        private void CreateSettingsGui()
        {
            this.settingsGui = new SettingsPage();

        }

        public string Name
        {
            get { return "Numbers"; }
        }
    }
}
