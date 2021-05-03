using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        //Background worker to load database
        private readonly BackgroundWorker worker = new();

        // List with the data that will be shown through the datagrid
        private List<Trash> Database;


        public DisplayDataPage()
        {
            InitializeComponent();
            // Assignning the different tasks
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
        }


        /// <summary>
        /// The work the worker has to do async
        /// <para>Created by Kasper</para>
        /// </summary>
        private void worker_DoWork(object sender, DoWorkEventArgs e) => Database = SqlQueries.GetTrashFromDb();

        /// <summary>
        /// The workers final task after finshing the first
        /// <para>Created by Kasper</para>
        /// </summary>
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => DbDisplayer.ItemsSource = Database;

        /// <summary>
        /// The worker being started and run async.
        /// <para>Created by Kasper</para>
        /// </summary>
        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e) => worker.RunWorkerAsync();
    }

    
}
