using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Xml;
using System.ComponentModel.Composition;
using System.Reflection;
using LearningGames.Framework;
using System.ComponentModel.Composition.Hosting;

namespace LearningGames
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private NavigationManager navigationManager;

        void AppStartup(object sender, StartupEventArgs e)
        {
            // Create main application window, starting minimized if specified
            MainWindow mainWindow = new MainWindow();
            InitialiseMainWindow(mainWindow);
            mainWindow.Show();
        }

        void InitialiseMainWindow(MainWindow mainWindow)
        {
            var page = new MainMenuPage();
            this.navigationManager = new NavigationManager(new NavigationAdapter(mainWindow.navigationFrame), page);
            var mainWindowViewModel = new MainWindowViewModel();
            mainWindow.DataContext = mainWindowViewModel;

            var viewModel = new MainMenuViewModel();
            Compose(viewModel);
            page.DataContext = viewModel;
            mainWindow.navigationFrame.Navigate(page);
        }

        public void Compose(object viewModel)
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            catalog.Catalogs.Add(new DirectoryCatalog("."));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(viewModel);
        }
    }
}
