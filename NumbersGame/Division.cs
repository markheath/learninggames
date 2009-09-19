using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Numbers
{
    public class Division : Sum
    {
        public int First { get; private set; }
        public int Second { get; private set; }

        public Division(int first, int second)
        {
            this.First = first;
            this.Second = second;
        }

        public override bool IsCorrect(string answer)
        {
            int answerInt;
            if (Int32.TryParse(answer, out answerInt))
            {
                return answerInt == First / Second;
            }
            return false;
        }

        public override object Content
        {
            get { return ToString(); }
        }

        public override string ToString()
        {
            if (Second == 2)
            {
                return String.Format("Half of {0}", First);
            }
            return String.Format("{0} ÷ {1}", First, Second);
        }
    }
}
