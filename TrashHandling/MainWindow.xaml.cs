using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TrashHandling.Pages;

namespace TrashHandling
{
	/// <summary>
	/// The main page's view. Connects to all the pages via a frame.
	/// <para> Created by Kasper</para>
	/// </summary>
	public partial class MainWindow : Window
    {
        public static MainWindow Main;

        /// Pages under the Directory 
        static HomePage HomePage = new();
        static RegisterTrashPage RegisterPage = new();
        static DisplayDataPage DisplayDataPage = new();
        static ImportPage ImportPage = new();
        static StatisticsPage StatisticsPage = new();
        static ConsolePage ConsolePage = new();

        /// The Directory itself
        private readonly Dictionary<string, Page> PageDirectory = new()
        {
            { "Home", HomePage},
            { "Registrér affald", RegisterPage },
            { "Display Data", DisplayDataPage },
            { "Import fra .csv", ImportPage},
            { "Statistik", StatisticsPage },
            { "Console",  ConsolePage }

        };

        /// <summary>
        /// The MainWindow class
        /// <para>Created by Kasper</para>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Main = this;
            viewingWindow.Navigate(new LoginPage());


            // Add event to all menu items (including children)
            foreach (MenuItem item in Topbar.Items)
            {
                if(item.HasItems)
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
                viewingWindow.Navigate(PageDirectory[header]);
            }
            catch (System.Exception err)
            {
                MessageBox.Show($"Seems that the page you are trying to reach, could not be reached!\nError: {err.Message}");
            }
        }


    }
}
