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
using LearningGames.Framework;

namespace LearningGames
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        NavigationManager navigationManager;

        public MainMenu()
        {
            InitializeComponent();
            var page = new MainMenuPage();
            this.navigationManager = new NavigationManager(new NavigationAdapter(navigationFrame), page);
            var mainWindowViewModel = new MainWindowViewModel();
            this.DataContext = mainWindowViewModel;
            navigationFrame.Navigated += new NavigatedEventHandler(navigationFrame_Navigated);
            
            var viewModel = new MainMenuViewModel();
            Compose(viewModel);            
            page.DataContext = viewModel;
            navigationFrame.Navigate(page);
        }

        public void Compose(object viewModel)
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));            
            catalog.Catalogs.Add(new DirectoryCatalog("."));            
            var container = new CompositionContainer(catalog);
            container.ComposeParts(viewModel);
        }

        void navigationFrame_Navigated(object sender, NavigationEventArgs e)
        {
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }
    }
}
