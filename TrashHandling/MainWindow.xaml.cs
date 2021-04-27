using System.Windows;
using System.Windows.Controls;
using TrashHandling.Pages;
using System.Collections.Generic;

namespace TrashHandling
{
    /// <summary>
    /// The main page's view. Connects to all the pages via a frame.
    /// <para> Created by Kasper</para>
    /// </summary>
    public partial class MainWindow : Window
    {
        // Pages Directory
        /// Pages under the Directory 
        static ConsolePage ConsolePage = new ConsolePage();
        static Statistics StatisticsPage = new Statistics();
        static DisplayData DisplayDataPage = new DisplayData();
        static RegisterTrash RegisterPage = new RegisterTrash();
        /// The Directory itself
        Dictionary<string, Page> PageDirectory = new Dictionary<string, Page>()
        {
            { "Home", null},
            { "Registér affald", RegisterPage },
            { "Display Data", DisplayDataPage },
            { "Import fra .csv", null },
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
            viewingWindow.Navigate(null);


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
