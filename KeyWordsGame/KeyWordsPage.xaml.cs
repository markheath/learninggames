﻿using System;
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
using System.Xml.Linq;
using System.ComponentModel.Composition;

namespace LearningGames.KeyWords
{
    /// <summary>
    /// Interaction logic for KeyWordsPage.xaml
    /// </summary>
    [Export("Game")]
    public partial class KeyWordsPage : System.Windows.Controls.Page
    {
        public KeyWordsPage()
        {
            InitializeComponent();
        }
    }
}
