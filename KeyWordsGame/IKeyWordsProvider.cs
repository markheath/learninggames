using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.KeyWords
{
    interface IKeyWordsProvider
    {
        IEnumerable<string> GetGroupNames();
        IEnumerable<string> GetKeyWords(string group);
    }
}
