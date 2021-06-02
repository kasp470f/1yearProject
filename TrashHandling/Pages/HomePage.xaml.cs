using System.Windows.Controls;
using TrashHandling.Models;
using System.Windows;

namespace TrashHandling.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// <para>Created by Kasper</para>
    /// </summary>
    public partial class HomePage : Page
	{
        /// <summary>
        /// Constructor for the Home page
        /// <para>Created by Kasper</para>
        /// </summary>
		public HomePage()
		{
			InitializeComponent();
		}

        /// <summary>
        /// The logout button that will remove the current instnce of the company selected.
        /// <para>Created by Kasper</para>
        /// </summary>
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Company.RemoveInstance = null;
            MainWindow.App.Topbar.IsEnabled = false;
            MainWindow.App.SwitchPage(new LoginPage());
            Filewatcher.watcher.EnableRaisingEvents = false;
            MainWindow.App.Title = "Log ind";
        }

        /// <summary>
        /// User name will be displayed on home page.
        /// <para>Created by Kasper</para>
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserName.Text = Company.Instance.Name;
        }
    }
}
