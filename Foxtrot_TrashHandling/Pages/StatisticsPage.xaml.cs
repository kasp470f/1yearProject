using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        /// <summary>
        /// Constructor for the Statistics page
        /// <para>Created by Kasper</para>
        /// </summary>
        public StatisticsPage()
        {
            InitializeComponent();

            int year = DateTime.Now.Year;
            for (int i = year; i >= 1980; i--) yearPicked.Items.Add(i);
            yearPicked.SelectedItem = year;
        }

        /// <summary>
        /// When the user switches between the categories and year
        /// <para>Created by Kasper</para>
        /// </summary>
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.IsLoaded) LoadBarChartData();
        }


        /// <summary>
        /// Loads the chart with information
        /// <para>Created by Kasper</para>
        /// </summary>
        private void LoadBarChartData()
        {
            ((ColumnSeries)TrashChart.Series[0]).ItemsSource = null;
            ((ColumnSeries)TrashChart.Series[0]).ItemsSource = AccumulatedAmount(SqlQueries.GetTrashFromDb(), int.Parse(yearPicked.SelectedItem.ToString()), TrashPicker.SelectedIndex + 1);
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
            CultureInfo dk = new("da-DK");

            // Initializing the temp dictionary
            Dictionary<int, decimal> tempDictionary = new();
            for (int i = 1; i <= 12; i++) tempDictionary.Add(i, 0);

            // Sort the insertedList
            List<Trash> yourCompany = trashlist.Where(x => x.CompanyId == Company.Instance.Id).ToList();
            List<Trash> query = yourCompany.Where(x => DateTime.ParseExact(x.RegisterTimeStamp, format, dk).Year == year && x.Category == category).ToList();
            // Sum up the amounts for each month
            foreach (Trash element in query)
            {
                decimal amount = 0;
                switch (element.Unit)
                {
                    // Ton
                    case 3:
                        amount = element.Amount * 1000;
                        break;
                    // Kilogram
                    case 4:
                        amount = element.Amount;
                        break;
                    // Gram 
                    case 5:
                        amount = element.Amount / 1000;
                        break;
                }
                tempDictionary[DateTime.ParseExact(element.RegisterTimeStamp, format, dk).Month] += Math.Round(amount, 3);
            }

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
