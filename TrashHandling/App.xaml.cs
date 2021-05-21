using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TrashHandling
{
	public partial class App : Application
    {
        /// <summary>
        /// Allows the user to press the box instead of only the icon for it to open.
        /// <para>Created by Kasper</para>
        /// </summary>
        private void DatePicker_Click(object sender, MouseButtonEventArgs e)
        {
            DatePicker datePicker = e.Source as DatePicker;
            datePicker.IsDropDownOpen = true;
        }
    }
}
