using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        public static DisplayDataPage DisplayWindow;

        //Background worker to load database
        private readonly BackgroundWorker worker = new();

        // List with the data that will be shown through the datagrid
        private List<Trash> Database;

        public DisplayDataPage()
        {
            InitializeComponent();
            DisplayWindow = this;
            // Assignning the different tasks
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }
        
        /// <summary>
        /// Allows to open the selected row
        /// <para>Created by Martin</para>
        /// </summary>
        private void OpenEditableData_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
			{
			    DataGridRow row = sender as DataGridRow;
				Trash trash = (Trash)row.Item;
				if(trash.CompanyId == Company.Instance.Id)
                {
                    ChangeDataWindow changeData = new(trash);
                    changeData.Show();
                }
            }
		}

        /// <summary>
        /// The logic behind the button that allows for export of CSV
        /// <para>Created by Kasper</para>
        /// </summary>
        private void ExportDB_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog selector = new() {
                Title = "Choose the location of the Database Content",
                Filter = "CSV (Comma Delimited) (*.csv)|*.csv|Text file (*.txt)|*.txt",
                InitialDirectory = @"C:\Dropzone",
            };
            Filewatcher.watcher.EnableRaisingEvents = false;
            if (selector.ShowDialog() == true)
            {
                string databaseText = string.Empty;
                foreach (Trash element in DbDisplayer.ItemsSource)
                {
                    databaseText += $"{element.ToString()}\n";
                }
                File.WriteAllText(selector.FileName, databaseText);
            }
            Filewatcher.watcher.EnableRaisingEvents = true;
        }

        #region Background Worker
        /// <summary>
        /// The work the worker has to do async
        /// <para>Created by Kasper</para>
        /// </summary>
        private void worker_DoWork(object sender, DoWorkEventArgs e) => Database = SqlQueries.GetTrashFromDb();

        /// <summary>
        /// The workers final task after finishing the first
        /// <para>Created by Kasper</para>
        /// </summary>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (ShowAllCheckbox.IsChecked == false) DbDisplayer.ItemsSource = Database.Where(x => x.CompanyId == Company.Instance.Id);
            else DbDisplayer.ItemsSource = Database;
        }

        /// <summary>
        /// The worker being started and run async.
        /// <para>Created by Kasper</para>
        /// </summary>
        private void Page_Loaded(object sender, RoutedEventArgs e) => worker.RunWorkerAsync();
        #endregion

        /// <summary>
        /// Refresh the datagrid to update with new info
        /// <para>Created by Kasper</para>
        /// </summary>
        public void RefreshDataGrid()
        {
            DbDisplayer.ItemsSource = null;
            DbDisplayer.Items.Clear();
            DbDisplayer.Items.Refresh();
            worker.RunWorkerAsync();
        }

        private void ShowAllCheckbox_Checked(object sender, RoutedEventArgs e) => RefreshDataGrid();

        private void ShowAllCheckbox_Unchecked(object sender, RoutedEventArgs e) => RefreshDataGrid();
    }
}