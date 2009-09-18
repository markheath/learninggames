using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Numbers
{
    class Subtraction : Sum
    {
        public Subtraction()
        {
            this.Operator = Operator.Subtract;
        }

        public override int Answer
        {
            get
            {
                return First - Second;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} - {1}", First, Second);
        }
    }
}
