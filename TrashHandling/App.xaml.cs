using System.Windows;
using System.Windows.Controls;
using TrashHandling.Models;

namespace TrashHandling
{
    public partial class App : Application
    {
        /// <summary>
        /// Allows the user to press the box instead of only the icon for it to open.
        /// <para>Created by Kasper</para>
        /// </summary>
        private void DatePicker_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DatePicker datePicker = e.Source as DatePicker;
            datePicker.IsDropDownOpen = true;
        }
    }
}
