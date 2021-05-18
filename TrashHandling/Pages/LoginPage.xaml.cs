using System;
using System.Windows;
using System.Windows.Controls;
using TrashHandling.Models;

namespace TrashHandling.Pages
{
	/// <summary>
	/// Interaction logic for LoginPage.xaml
	/// </summary>
	public partial class LoginPage : Page
	{
		public LoginPage()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Allows the user to login.
        /// <para>Created by Kasper</para>
        /// </summary>
		private void Login_Click(object sender, RoutedEventArgs e)
		{
            try
            {
                if (UserName.Text != string.Empty && int.TryParse(UserCompany.Text, out int id) == true)
                {
                    if (Models.Validation.ValidCompanyInfo(id) == true)
                    {
                        new Company(UserName.Text, id);
                        Console.Log($"User logged in: {UserName.Text}, {UserCompany.Text}");
                        MainWindow.Main.Topbar.IsEnabled = true;
                        MainWindow.Main.viewingWindow.Navigate(new HomePage());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
		}

        /// <summary>
        /// The method to remove placeholder text
        /// <para>Created by Kasper</para>
        /// </summary>
        private void UserCompany_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UserCompany.Text == "Skriv CVR ID") UserCompany.Text = string.Empty;
        }
    }
}
