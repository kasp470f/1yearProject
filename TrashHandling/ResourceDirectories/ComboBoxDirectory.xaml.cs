using System;
using System.Windows;
using System.Windows.Controls;
using TrashHandling.Models;

namespace TrashHandling.ResourceDirectories
{
    /// <summary>
    /// <para>Created by Kasper</para>
    /// </summary>
    public partial class ComboBoxDirectory : ResourceDictionary
    {
        /// <summary>
        /// Loads the comboboxes with the correct itemsource.
        /// <para>Created by Kasper</para>
        /// </summary>
        private void LoadComboBoxes(object sender, RoutedEventArgs e)
        {
            ComboBox box = e.Source as ComboBox;
            if (box.HasItems == false)
            {
                switch (box.Name)
                {
                    case "TrashPicker":
                        box.ItemsSource = ComboBoxSources.CategoriesValues;
                        box.SelectedItem = ComboBoxSources.Categories[1];
                        break;
                    case "UnitPicker":
                        ComboBoxSources.Units[] units = (ComboBoxSources.Units[])Enum.GetValues(typeof(ComboBoxSources.Units));
                        box.ItemsSource = units[2..5];
                        break;
                }
            }
        }
    }
}
