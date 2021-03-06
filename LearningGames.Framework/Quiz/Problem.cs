﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace LearningGames.Framework.Quiz
{
    public abstract class Problem
    {
        public abstract FrameworkElement Presenter { get; }
        public event EventHandler Answered;
        public bool IsCorrect { get; private set; }
        public int Attempts { get; private set; }

        public DataTemplate DataTemplate
        { 
            get 
            { 
                string resourceName = this.GetType().Name;
                return (DataTemplate) Application.Current.Resources[resourceName];
            }
        }

        public void RaiseAnswerEvent(bool isCorrect)
        {
            this.IsCorrect = isCorrect;
            this.Attempts++;

            if (Answered != null)
            {
                Answered(this, EventArgs.Empty);
            }
        }

        public abstract object GetViewModel();
    }    
}
