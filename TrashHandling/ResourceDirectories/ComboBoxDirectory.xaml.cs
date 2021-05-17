using System;
using System.Windows;
using System.Windows.Controls;
using TrashHandling.Models;

namespace TrashHandling.ResourceDirectories
{
    public partial class ComboBoxDirectory : ResourceDictionary
    {
        /// <summary>
        /// Loads the comboboxes with the correct itemsource.
        /// <para>Created by Kasper</para>
        /// </summary>
        private void LoadComboBoxes(object sender, RoutedEventArgs e)
        {
            ComboBox box = e.Source as ComboBox;
            switch (box.Name)
            {
                case "TrashPicker":
                    box.ItemsSource = ComboBoxSources.CategoriesValues;
                    box.SelectedItem = ComboBoxSources.Categories[1];
                    break;
                case "UnitPicker":
                    box.ItemsSource = Enum.GetValues(typeof(ComboBoxSources.Units));
                    break;
            }
        }
    }
}
