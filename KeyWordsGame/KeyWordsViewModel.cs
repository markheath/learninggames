using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Input;
using LearningGames.Framework;

namespace LearningGames.KeyWords
{
    class KeyWordsViewModel : ViewModelBase
    {
        KeyWordsManager manager;
        ICommand correctCommand;
        ICommand incorrectCommand;
        
        ISpeechService speechService;

        public KeyWordsViewModel(IEnumerable<KeyWord> keyWords, ISpeechService speechService)
        {
            this.manager = new KeyWordsManager(keyWords);
            this.speechService = speechService;
        }

        public ICommand Correct
        {
            get
            {
                if (correctCommand == null)
                {
                    correctCommand = new RelayCommand(
                        () => this.OnCorrectClick(),
                        () => true);
                }
                return correctCommand;
            }
        }

        public ICommand Incorrect
        {
            get
            {
                if (incorrectCommand == null)
                {
                    incorrectCommand = new RelayCommand(
                        () => this.OnIncorrectClick(),
                        () => true);
                }
                return incorrectCommand;
            }
        }

        void OnCorrectClick()
        {
            manager.Correct();
            RaisePropertyChangedEvent("Right");
            RaisePropertyChangedEvent("KeyWord");
        }

        public string Right
        {
            get { return manager.Right.ToString(); }
        }

        public string Wrong
        {
            get { return manager.Wrong.ToString(); }
        }

        public string KeyWord
        {
            get { return manager.Word; }
        }


        void OnIncorrectClick()
        {
            speechService.Speak(KeyWord, null);
            manager.Incorrect();
            RaisePropertyChangedEvent("Wrong");
            RaisePropertyChangedEvent("KeyWord");
        }
    }
}
