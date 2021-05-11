using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using TrashHandling.Models;

namespace TrashHandling.Pages
{
	/// <summary>
	/// Interaction logic for ImportPage.xaml
	/// <para>Created by Martin</para>
	/// </summary>
	public partial class ImportPage : Page
	{
		public static string dirPath = @"C:\Dropzone";
		private List<Trash> localFiles = new();

		public ImportPage()
		{
			InitializeComponent();
			if (!Directory.Exists(dirPath))
			{
				Directory.CreateDirectory(dirPath);
			}
			//MonitorDirectory(dirPath);
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
				Filter = "CSV (Comma Delimited) (*.csv)|*.csv",
				CheckPathExists = true,
				Multiselect = true,
			};		
			
			if(selector.ShowDialog()  == true)
			{
				string[] paths = selector.FileNames;
				string[] pathsNames = selector.SafeFileNames;
				FileNameField.Text = string.Join(", ", paths);
				FormatLocalFiles(paths, pathsNames);

			}
		}


		private void FormatLocalFiles(string[] paths, string[] fileNames)
        {
			localFiles = new();
            try
            {
				for (int i = 0; i < paths.Length; i++)
				{
					string[] content = File.ReadAllLines(paths[i]);
					foreach (string line in content)
					{
						string[] element = line.Split("\",\"");
						localFiles.Add(new Trash()
						{
							IdText = $"{fileNames[i]} / {element[0].Trim('\"')}",
							Amount = int.Parse(element[1]),
							Unit = int.Parse(element[2]),
							Category = int.Parse(element[3]),
							Description = element[4],
							ResponsiblePerson = element[5],
							CompanyId = int.Parse(element[6]),
							RegisterTimeStamp = element[7].Trim('\"'),
						});
					}
				}
			}
            catch (Exception ex)
            {
				MessageBox.Show(ex.Message);
            }

			ImportDisplay.ItemsSource = null;
			ImportDisplay.Items.Clear();
			ImportDisplay.ItemsSource = localFiles;

		}


        #region Not Working
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
        #endregion
    }
}
