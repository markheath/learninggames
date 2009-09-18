using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using LearningGames.KeyWords;

namespace LearningGames.KeyWords
{
    class KeyWordXmlProvider : IKeyWordsProvider
    {
        XElement xraw;

        public KeyWordXmlProvider(string path)
        {
            this.xraw = XElement.Load(path);
        }

        public IEnumerable<string> GetGroupNames()
        {
            var groups = from groupNode in xraw.Elements("Group")
                          select groupNode.Value;
            return groups;
        }

        public IEnumerable<KeyWord> GetKeyWords(string groupName)
        {
            var keyWords = from groupNode in xraw.Elements("Group") where groupNode.Attribute("Name").Value == groupName
                           from keyWordNode in groupNode.Elements("KeyWord")
                           select new KeyWord
                            {
                                Word = keyWordNode.Value,
                                Group = groupName,
                            };
            return keyWords;
        }

        /* Snippet: to get all keywords:
         *                     var keyWords = (from keyWord in
                            xraw.Elements("Group").Elements("KeyWord")
                        select new KeyWord
                        {
                            Word = keyWord.Value,
                            Group = (string)keyWord.Parent.Attribute("Name"),
                        });
           */
        
    }
}
