using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TrashHandling.Models;
using TrashHandling.Pages;

namespace TrashHandling
{
	/// <summary>
	/// The main page's view. Connects to all the pages via a frame.
	/// <para> Created by Kasper</para>
	/// </summary>
	public partial class MainWindow : Window
    {
        public static MainWindow App;

        /// Pages under the Directory 
        static HomePage HomePage = new();
        static RegisterTrashPage RegisterPage = new();
        static DisplayDataPage DisplayPage = new();
        static ImportPage ImportPage = new();
        static StatisticsPage StatisticsPage = new();
        static ConsolePage ConsolePage = new();

        /// The Directory itself
        private readonly Dictionary<string, Page> PageDirectory = new()
        {
            { "Hjem", HomePage},
            { "Registrér affald", RegisterPage },
            { "Vis data", DisplayPage },
            { "Importér fra csv", ImportPage},
            { "Statistik", StatisticsPage },
            { "Log",  ConsolePage }

        };

        /// <summary>
        /// The MainWindow class
        /// <para>Created by Kasper</para>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            App = this;
            viewingWindow.Navigate(new LoginPage());


            // Add event to all menu items (including children)
            foreach (MenuItem item in Topbar.Items)
            {
                if(item.Header.ToString() != "Log ud")
                {
                    if (item.HasItems)
                    {
                        foreach (MenuItem childItem in item.Items)
                        {
                            item.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(MenuItem_Click));
                        }
                    }
                    else
                    {
                        item.AddHandler(MenuItem.ClickEvent, new RoutedEventHandler(MenuItem_Click));
                    }
                }
            }

        }

        /// <summary>
        /// This method is used to navigate all the pages. 
        /// <para>Created by Kasper</para>
        /// </summary>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Cast event source.
            MenuItem item = e.Source as MenuItem;
            // Change the Title of the window.
            string header = item.Header.ToString();
            this.Title = header;
            try
            {
                SwitchPage(PageDirectory[header]);
            }
            catch (System.Exception err)
            {
                MessageBox.Show($"Seems that the page you are trying to reach, could not be reached!\nError: {err.Message}");
            }
        }

        public void SwitchPage(Page page)
        {
            this.Dispatcher.Invoke(() =>
            {
                viewingWindow.Navigate(page);
            });
        }

        /// <summary>
        /// The logout button that will remove the current instnce of the company selected.
        /// <para>Created by Kasper</para>
        /// </summary>
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Company.RemoveInstance = null;
            App.Topbar.IsEnabled = false;
            App.SwitchPage(new LoginPage());
            Filewatcher.watcher.EnableRaisingEvents = false;
            App.Title = "Log ind";
        }
    }
}
