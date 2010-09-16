using System;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Xml;
using System.ComponentModel.Composition;
using System.Reflection;
using LearningGames.Framework;
using System.ComponentModel.Composition.Hosting;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;

namespace LearningGames
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private NavigationManager navigationManager;

        public App()
        {
            this.Startup += this.Application_Startup;
            this.Exit += this.Application_Exit;
#if SILVERLIGHT
            this.UnhandledException += this.Application_UnhandledException;
            InitializeComponent();
#endif
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Create main application window, starting minimized if specified
            MainWindow mainWindow = new MainWindow();
            InitialiseMainWindow(mainWindow);

#if SILVERLIGHT
            this.RootVisual = mainWindow;
#else
            mainWindow.Show();
#endif
        }

        private void Application_Exit(object sender, EventArgs e)
        {

        }

#if SILVERLIGHT
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached)
            {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }

        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }
#endif

        void InitialiseMainWindow(MainWindow mainWindow)
        {
            var mainWindowViewModel = new MainWindowViewModel();
            mainWindow.DataContext = mainWindowViewModel;
            
            var page = new MainMenuPage();
            this.navigationManager = new NavigationManager(new NavigationAdapter(mainWindow.navigationFrame), page);
            var viewModel = new MainMenuViewModel(GetGames());

            page.DataContext = viewModel;
            Messenger.Default.Send<GoHomeMessage>(new GoHomeMessage());
        }

        public IEnumerable<IGame> GetGames()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
#if SILVERLIGHT
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(LearningGames.KeyWords.KeyWordsGame).Assembly));
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(LearningGames.Numbers.NumbersGame).Assembly));
#else
            catalog.Catalogs.Add(new DirectoryCatalog("."));
#endif
            var container = new CompositionContainer(catalog);
            //container.ComposeParts(viewModel);
            return container.GetExportedValues<IGame>();
        }
    }
}
