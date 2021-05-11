using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using TrashHandling.Models;

namespace TrashHandling.Pages
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// <para>Created by Kasper</para>
    /// </summary>
    public partial class StatisticsPage : Page
    {
        public StatisticsPage()
        {
            InitializeComponent();
            //LoadBarChartData();

            int year = DateTime.Now.Year;
            for (int i = year; i >= year - 100; i--) yearPicked.Items.Add(i);
            yearPicked.SelectedItem = year;
        }

        /// <summary>
        /// When the user switches between the trash categories
        /// <para>Created by Kasper</para>
        /// </summary>
        private void TrashPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadBarChartData();
        }


        /// <summary>
        /// Loads a chart
        /// <para>Created by Kasper</para>
        /// </summary>
        private void LoadBarChartData()
        {
            ((ColumnSeries)TrashChart.Series[0]).ItemsSource = null;
            ((ColumnSeries)TrashChart.Series[0]).ItemsSource = AccumulatedAmount(SqlQueries.GetTrashFromDb(), DateTime.Now.Year, TrashPicker.SelectedIndex + 1);
            Console.Log($"Graph was created");
        }


        /// <summary>
        /// A function that allows to get dictionary with all the requested information for a graph.
        /// <para>Created by Kasper</para>
        /// </summary>
        /// <param name="trashlist">A list with all the trash elements</param>
        /// <param name="year">Which year you want to see</param>
        /// <param name="category">The trash category</param>
        /// <returns>Dictionary with accumulated amounts for specified year</returns>
        public static Dictionary<string, decimal> AccumulatedAmount(List<Trash> trashlist, int year, int category)
        {
            // Format elements
            string format = "yyyy:MM:dd HH:mm";
            CultureInfo dk = new CultureInfo("da-DK");

            // Initializing the temp dictionary
            Dictionary<int, decimal> tempDictionary = new();
            for (int i = 1; i <= 12; i++) tempDictionary.Add(i, 0);

            // Sort the insertedList
            List<Trash> query = trashlist.Where(x => DateTime.ParseExact(x.RegisterTimeStamp, format, dk).Year == year && x.Category == category).ToList();
            // Sum up the amounts for each month
            foreach (Trash element in query) tempDictionary[DateTime.ParseExact(element.RegisterTimeStamp, format, dk).Month] += element.Amount;

            // Change it to string keys
            string[] monthNames = CultureInfo.CurrentCulture.DateTimeFormat.MonthGenitiveNames.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            Dictionary<string, decimal> returnDictionary = new();
            foreach (KeyValuePair<int, decimal> element in tempDictionary)
            {
                returnDictionary.Add(monthNames[element.Key-1], element.Value);
            }
            return returnDictionary;
        }
    }
}
