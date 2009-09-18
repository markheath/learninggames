using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Numbers
{
    class Division : Sum
    {
        public Division()
        {
            this.Operator = Operator.Divide;
        }

        public override int Answer
        {
            get
            {
                return First / Second;
            }
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
