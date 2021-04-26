using System.Windows;
using TrashHandling.Pages;

namespace TrashHandling
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            viewingWindow.Navigate(new Console());
        }
    }
}
