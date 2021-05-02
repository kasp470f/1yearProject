using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;

namespace TrashHandling
{
    public partial class App : Application
    {
        private void DatePicker_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DatePicker datePicker = e.Source as DatePicker;
            datePicker.IsDropDownOpen = true;
        }
    }
}
