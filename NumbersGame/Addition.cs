using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Numbers
{
    public class Addition : Sum
    {
        public int First { get; private set; }
        public int Second { get; private set; }

        public Addition(int first, int second)
        {
            this.First = first;
            this.Second = second;
        }

        public override bool IsCorrect(string answer)
        {
            int answerInt;
            if(Int32.TryParse(answer, out answerInt))
            {
                return answerInt == First + Second;
            }
            return false;
        }

        public override object Content
        {
            get { return ToString(); }
        }

        public override string ToString()
        {
            return String.Format("{0} + {1}", First, Second);
        }
    }
}
