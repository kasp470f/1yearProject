using System.Windows.Controls;
using System.Windows;

namespace TrashHandling.Pages
{
    /// <summary>
    /// The view page of the Console page
    /// <para> Created by Kasper</para>
    /// </summary>
    public partial class ConsolePage : Page
    {
        public static ConsolePage App;

        /// <summary>
        /// Constructor for the Console page
        /// <para>Created by Kasper</para>
        /// </summary>
        public ConsolePage()
        {
            InitializeComponent();
            App = this;
        }

        /// <summary>
        /// Writes a message in the log textbox
        /// <para> Created by Kasper</para>
        /// </summary>
        /// <param name="messsage">The string to be writen in the textbox</param>
        public void Write(string messsage)
        {
            consoleBox.Text += $"{messsage}\n";
        }


        /// <summary>
        /// Export the contents of the console box to a text file
        /// <para> Created by Kasper</para>
        /// </summary>
        private void ExportLog_Click(object sender, RoutedEventArgs e)
        {
            Console.Log("User has exported the logs to txt file format");
        }

        /// <summary>
        /// Changes the mouse position to the newest change.
        /// <para> Created by Kasper</para>
        /// </summary>
        private void ScrollToEnd_Changed(object sender, TextChangedEventArgs e)
        {
            consoleBox.ScrollToEnd();
        }
    }

    /// <summary>
    /// Class that just helps reach the ConsoleApp View
    /// <para> Created by Kasper</para>
    /// </summary>
    public static class Console
    {
        /// <summary>
        /// Allows to write in the ConsolePage App's Console Box
        /// <para> Created by Kasper</para>
        /// </summary>
        /// <param name="message">The string that you want to print in the textbox</param>
        public static void Log(string message)
        {
            ConsolePage.App.Write(message);
        }
    }
}
