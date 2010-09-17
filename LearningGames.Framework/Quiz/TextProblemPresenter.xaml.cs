using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace LearningGames.Framework.Quiz
{
    /// <summary>
    /// Interaction logic for TextProblemPresenter.xaml
    /// </summary>
    public partial class TextProblemPresenter : UserControl
    {
        public TextProblemPresenter()
        {
            InitializeComponent();
            this.Loaded += (sender, e) => textBoxAnswer.Focus();
#if !SILVERLIGHT
            // not sure why we need to do this in code
            StoryboardManager.SetID((Storyboard)this.Resources["rightAnswerAnimation"], "rightAnswerAnimation");
            StoryboardManager.SetID((Storyboard)this.Resources["wrongAnswerAnimation"], "wrongAnswerAnimation");
#endif
        }
    }
}
