using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace TrashHandling.Pages
{
	/// <summary>
	/// Interaction logic for ImportPage.xaml
	/// <para>Created by Martin</para>
	/// </summary>
	public partial class ImportPage : Page
	{
		public static string dirPath = @"C:\Dropzone";

		public ImportPage()
		{
			InitializeComponent();
			if (!Directory.Exists(dirPath))
			{
				Directory.CreateDirectory(dirPath);
			}
			MonitorDirectory(dirPath);
		}

		///<Summary>
		///Opens a window to pick a .csv file from a specific directory: C:\Dropzone which is defined in the project assignment as our predefined folder
		///Window shows .csv-files only
		///After file is accepted, a preview of the data in it will be shown
		///<para>Created by Martin</para>
		///</Summary>
		private void PickFile_Click(object sender, RoutedEventArgs e)
		{
			FileNameField.Text = "";
			OpenFileDialog selector = new OpenFileDialog()
			{
				Title = "Open .csv-file",
				InitialDirectory = dirPath,
				Filter = "CSV files (*.csv)|*csv",
				CheckPathExists = true
			};			
			bool? fileOk = selector.ShowDialog();

			if (fileOk == true)
			{
				FileNameField.Text = selector.FileName.ToString();

				//TODO: What to do after file is opened?
				MessageBox.Show("Succes!!");
			}
		}

		/// <summary>
		/// Monitors a directory for additions of files that are csv format.
		/// <para>Created by Kasper</para>
		/// </summary>
		/// <param name="path">The path to monitor</param>
		private static void MonitorDirectory(string path)
		{
			FileSystemWatcher fileSystemWatcher = new (path);
			fileSystemWatcher.Filter = "*.csv";
			fileSystemWatcher.Created += File_Added;
			fileSystemWatcher.EnableRaisingEvents = true;
		}

		/// <summary>
		/// The Method that is sent when a file is added to the monitored folder
		/// <para>Created by Kasper</para>
		/// </summary>
		private static void File_Added(object sender, FileSystemEventArgs e)
		{
			MessageBox.Show(e.Name);
		}
	}
}
