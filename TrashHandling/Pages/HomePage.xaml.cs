using System.Windows.Controls;
using TrashHandling.Models;
using System.Windows;

namespace TrashHandling.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// <para>Created by Martin</para>
    /// </summary>
    public partial class HomePage : Page
	{
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
            MainWindow.Main.Topbar.IsEnabled = false;
            MainWindow.Main.viewingWindow.Navigate(new LoginPage());
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
