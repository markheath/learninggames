using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.ComponentModel.Composition;

namespace LearningGames.Numbers
{
    /// <summary>
    /// Interaction logic for NumbersPage.xaml
    /// </summary>
    [Export("Game")]
    public partial class NumbersPage : Page
    {
        public NumbersPage()
        {
            InitializeComponent();
        }
    }
}
