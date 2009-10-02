using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel.Composition;

namespace LearningGames.KeyWords
{
    [Export(typeof(IGame))]
    class KeyWordsGame : IGame
    {
        Page gui;
        Page settingsGui;

        public KeyWordsGame()
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
            var keywordsPage = new KeyWordsPage();
            var keyWordProvider = new KeyWordXmlProvider("KeyWords.xml");
            var wordsList = keyWordProvider.GetKeyWords("Y1/2 Key Words");
            var speechService = new SpeechService();
            keywordsPage.DataContext = new KeyWordsViewModel(wordsList, speechService);
            gui = keywordsPage;
        }

        private void CreateSettingsGui()
        {
            settingsGui = new SettingsPage();
        }


        public string Name
        {
            get { return "Key Words"; }
        }
    }
}
