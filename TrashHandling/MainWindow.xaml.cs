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
        // Pages List
        HomePage HomePage = new HomePage();
        ConsolePage ConsolePage = new ConsolePage();
        Statistics StatisticsPage = new Statistics();
        DisplayData DisplayDataPage = new DisplayData();
        RegisterTrash RegisterPage = new RegisterTrash();
        ImportPage ImportPage = new ImportPage();

        /// <summary>
        /// The MainWindow class
        /// <para>Created by Kasper</para>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            viewingWindow.Navigate(HomePage);


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
                switch (header)
                {
                    case "Home":
                        viewingWindow.Navigate(HomePage);
                        break;
                    case "Registrér affald":
                        viewingWindow.Navigate(RegisterPage);
                        break;
                    case "Display Data":
                        viewingWindow.Navigate(DisplayDataPage);
                        break;
                    case "Import fra .csv":
                        viewingWindow.Navigate(ImportPage);
                        break;
                    case "Export til .csv":
                        // Not Implemented
                        break;
                    case "Statistik":
                        viewingWindow.Navigate(StatisticsPage);
                        break;
                    case "Console":
                        viewingWindow.Navigate(ConsolePage);
                        break;
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show($"Seems that the page you are trying to reach, could not be reached!\nError: {err.Message}");
            }
        }
    }
}
