using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace LearningGames
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
            Compose();
            navigationFrame.Navigated += new NavigatedEventHandler(navigationFrame_Navigated);
            var page = new MainMenuPage();
            page.DataContext = ViewModel;
            navigationFrame.Navigate(page);
        }

        public void Compose()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));            
            catalog.Catalogs.Add(new DirectoryCatalog("."));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        [Import(typeof(MainMenuViewModel))]
        public MainMenuViewModel ViewModel { get; set; }

        void navigationFrame_Navigated(object sender, NavigationEventArgs e)
        {
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }
    }
}
