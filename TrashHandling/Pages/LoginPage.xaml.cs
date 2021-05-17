using System;
using System.Net;
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
                if (UserName.Text != string.Empty && ValidCompanyInfo(int.Parse(UserCompany.Text)) == true)
                {
                    new Company(UserName.Text, int.Parse(UserCompany.Text));
                }
                MainWindow.Main.Topbar.IsEnabled = true;
                MainWindow.Main.viewingWindow.Navigate(new HomePage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
		}

        /// <summary>
        /// Checks the company id against a API and sees if it is real.
        /// <para>Created by Kasper</para>
        /// </summary>
        /// <param name="id">The company id</param>
        /// <returns>true if company is found in the API</returns>
        public static bool ValidCompanyInfo(int id)
        {
            try
            {
                string resultContent;
                using (var webClient = new WebClient())
                {
                    webClient.Headers["User-Agent"] = "Uddanelses Projekt";
                    resultContent = webClient.DownloadString(string.Format("http://cvrapi.dk/api?search={0}&country=dk", id));
                }
                return !resultContent.Contains("error");
            }
            catch (Exception)
            {
                return false;
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
