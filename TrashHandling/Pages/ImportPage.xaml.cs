using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TrashHandling.Models;
using Validation = TrashHandling.Models.Validation;

namespace TrashHandling.Pages
{
    /// <summary>
    /// Interaction logic for ImportPage.xaml
    /// <para>Created by Kasper</para>
    /// </summary>
    public partial class ImportPage : Page
    {
        public static ImportPage App;
        public static string dirPath = @"C:\Dropzone";
        private List<Trash> localFiles;

        /// <summary>
        /// Constructor for the Import page
        /// <para>Created by Kasper</para>
        /// </summary>
        public ImportPage()
        {
            InitializeComponent();
            App = this;
            // Create Directory if not found
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            Filewatcher.Monitor(dirPath);
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

            if (selector.ShowDialog() == true)
            {
                string[] paths = selector.FileNames;
                string[] pathsNames = selector.SafeFileNames;
                FileNameField.Text = string.Join(", ", paths);
                FormatLocalFiles(paths, pathsNames);

            }
        }


        /// <summary>
        /// The method that makes the file, into a trash element.
        /// <para>Created by Kasper</para>
        /// </summary>
        /// <param name="path">The files path.</param>
        /// <param name="fileName">The name of the file.</param>
        public void FormatLocalFiles(string path, string fileName)
        {
            this.Dispatcher.Invoke(() =>
            {
                localFiles = new();
                try
                {

                    string[] content = File.ReadAllLines(path);
                    foreach (string line in content)
                    {
                        try
                        {
                            string[] element = line.Split("\",\"");
                            localFiles.Add(new Trash()
                            {
                                IdText = $"{fileName} / {element[0].Trim('\"')}",
                                Amount = Math.Round(CultureChange(element[1].Replace(',', '.')), 3),
                                Unit = int.Parse(element[2]),
                                Category = int.Parse(element[3]),
                                Description = element[4],
                                ResponsiblePerson = element[5],
                                CompanyId = int.Parse(element[6]),
                                RegisterTimeStamp = element[7].Trim('\"'),
                            });
                        }
                        catch { }
                    }
                    Console.Log($"A file has been added to import: {fileName}");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                ImportDisplay.ItemsSource = null;
                ImportDisplay.Items.Clear();
                ImportDisplay.ItemsSource = localFiles;
            });
        }

        /// <summary>
        /// The method that makes the files, into trash elements.
        /// <para>Created by Kasper</para>
        /// </summary>
        /// <param name="paths">The different files path.</param>
        /// <param name="fileNames">The names of the different files.</param>
        public void FormatLocalFiles(string[] paths, string[] fileNames)
        {
            localFiles = new();
            try
            {
                for (int i = 0; i < paths.Length; i++)
                {
                    string[] content = File.ReadAllLines(paths[i]);
                    foreach (string line in content)
                    {
                        try
                        {
                            string[] element = line.Split("\",\"");
                            localFiles.Add(new Trash()
                            {
                                IdText = $"{fileNames[i]} / {element[0].Trim('\"')}",
                                Amount = Math.Round(CultureChange(element[1].Replace(',', '.')), 3),
                                Unit = int.Parse(element[2]),
                                Category = int.Parse(element[3]),
                                Description = element[4],
                                ResponsiblePerson = element[5],
                                CompanyId = int.Parse(element[6]),
                                RegisterTimeStamp = element[7].Trim('\"'),
                            });
                        }
                        catch { }
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

        /// <summary>
        /// If computer is in Danish, we won't get correct English decimal numbers with "." so this method changes it to English format.
        /// <para>Created by Martin</para>
        /// </summary>
        public static decimal CultureChange(string input)
        {
            decimal.TryParse(input, NumberStyles.Number, CultureInfo.CreateSpecificCulture("en-GB"), out decimal converted);
            return converted;
        }


        /// <summary>
        /// When button pressed will add to database.
        /// <para>Created by Kasper</para>
        /// </summary>
        private void SaveImported_Click(object sender, RoutedEventArgs e)
        {
            //All elements from datagrid
            List<Trash> importList = new((List<Trash>)ImportDisplay.ItemsSource);

            //List of the items allowed into database
            List<Trash> insertList = new();

            //Take out elements with wrong Unit and CompanyId
            foreach (Trash item in importList)
            {
                if (item.Unit >= 3 && item.Unit <= 5 && Validation.ValidCompanyInfo(item.CompanyId)) insertList.Add(item);
                else continue;
            }

            //Add to database
            foreach (Trash element in insertList)
            {
                SqlQueries.InsertTrashToDb(element);
            }
            MessageBox.Show($"{insertList.Count} poster er tilføjet til databasen");
        }
    }
}
