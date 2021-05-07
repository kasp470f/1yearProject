using System;
using System.Collections.Generic;
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
        public List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
        public StatisticsPage()
        {
            InitializeComponent();
            LoadBarChartData();
        }

        /// <summary>
        /// Loads a random chart
        /// <para>Created by Kasper</para>
        /// </summary>
        private void LoadBarChartData()
        {
            Random random = new();
            for (int i = 0; i <= 60; i++)
            {
                list.Add(new KeyValuePair<string, int>(i.ToString(), random.Next(1, 10)));
            }
            ((ColumnSeries)TrashChart.Series[0]).ItemsSource = list;
        }
    }
}
