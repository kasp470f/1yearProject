using System.Linq;
using System.Windows.Controls;
using TrashHandling.Models;

namespace TrashHandling.Pages
{
	/// <summary>
	/// Interaction logic for DisplayDataPage.xaml
	/// <para>Created by Kasper</para>
	/// </summary>
	public partial class DisplayDataPage : Page
    {
        public DisplayDataPage()
        {
            InitializeComponent();
            BindTrashToDataGrid();
        }

        private void BindTrashToDataGrid()
        {
            DbDisplayer.ItemsSource = SqlQueries.GetTrashFromDb().ToList();
        }
    }

    
}
