using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Numbers
{
    class Addition : Sum
    {
        public Addition()
        {
            this.Operator = Operator.Add;
        }

        public override int Answer
        {
            get
            {
                return First + Second;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} + {1}", First, Second);
        }
    }
}
