using System.Linq;
using System.Windows.Controls;
using TrashHandling.Models;
using TrashHandling.Windows;

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
			DbDisplayer.ItemsSource = SqlQueries.GetTrashFromDb().ToList();
		}

		private void OpenEditableData_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			if (sender != null)
			{
				DataGridRow row = sender as DataGridRow;
				Trash trash = (Trash)row.Item;
				ChangeDataWindow changeData = new(trash);
				changeData.Show();
			}
		}
	}

    
}
