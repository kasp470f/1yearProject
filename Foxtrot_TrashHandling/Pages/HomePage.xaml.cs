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
        /// User name will be displayed on home page.
        /// <para>Created by Kasper</para>
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserName.Text = Company.Instance.Name;
        }
    }
}
