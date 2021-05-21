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

			// Create Directory if not found
			if (!Directory.Exists(dirPath))
			{
				Directory.CreateDirectory(dirPath);
			}
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
			OpenFileDialog selector = new()
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

		/// <summary>
		/// The method that makes the files, into trash elements.
		/// <para>Created by Kasper</para>
		/// </summary>
		/// <param name="paths">The different files path.</param>
		/// <param name="fileNames">The names of the different files.</param>
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
							Amount = Math.Round(decimal.Parse(element[1]),3),
							Unit = int.Parse(element[2]),
							Category = int.Parse(element[3]),
							Description = element[4],
							ResponsiblePerson = element[5],
							CompanyId = int.Parse(element[6]),
							RegisterTimeStamp = element[7].Trim('\"'),
						});
					}
					Console.Log($"A file has been added to import: {fileNames[i]}");
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

		private void SaveImported_Click(object sender, RoutedEventArgs e)
		{
			List<Trash> importList = new();
			bool trashOk = false;

			//TODO: Fill list here

			//Add to the db
			if (trashOk)
			{
				MessageBox.Show("Dine importerede data sendes til databasen. Vent venligst på at den bliver færdig.");
				int rowsAdded = 0;

				foreach (Trash importedElement in importList)
					rowsAdded += SqlQueries.InsertTrashToDb(importedElement);

				if (rowsAdded > 0)
				{
					Console.Log($"User imported {rowsAdded} row(s)");
					MessageBox.Show($"Succes! {rowsAdded} rækker tilføjet.");					
				}
			}			
		}
	}
}
