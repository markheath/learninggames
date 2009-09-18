﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LearningGames.Numbers
{
    class Multiplication : Sum
    {
        public Multiplication()
        {
            this.Operator = Operator.Multiply;
        }

        public override int Answer
        {
            get
            {
                return First * Second;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} × {1}", First, Second);
        }
    }
}
