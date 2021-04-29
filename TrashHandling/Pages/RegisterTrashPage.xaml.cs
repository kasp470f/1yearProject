using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TrashHandling.Models;

namespace TrashHandling.Pages
{
	/// <summary>
	/// Interaction logic for RegisterTrashPage.xaml
	/// <para>Created by Martin Nørholm</para>
	/// </summary>
	public partial class RegisterTrashPage : Page
	{
		public RegisterTrashPage()
		{
			InitializeComponent();
			TrashPicker.ItemsSource = ComboBoxSources.Categories;
			TrashPicker.SelectedItem = ComboBoxSources.Categories[0];

			UnitPicker.Items.Add(ComboBoxSources.Unit.Kg);
			UnitPicker.Items.Add(ComboBoxSources.Unit.Meter);
			UnitPicker.Items.Add(ComboBoxSources.Unit.Colli);
			
			
		}

		private void AddData_Click(object sender, RoutedEventArgs e)
		{
			//Makes a new Trash object and adds the content from the textboxes and comboboxes on RegisterTrashPage.
			Trash trash = new()
			{
				//Id autogenerates in database...
				Amount = decimal.Parse(Amount.Text),
				Units = UnitPicker.SelectedIndex + 1,
				Category = TrashPicker.SelectedItem.ToString(),
				Description = Description.Text,
				ResponsiblePerson = Registrator.Text,
				CompanyId = int.Parse(CompanyID.Text),
				//RegisterTimeStamp = $"{DatePickField.SelectedDate.Value:yyyy:MM:dd HH:mm}"
			};

			//Call the method to add to the db
			SqlQueries.InsertTrashToDb(trash);

			MessageBox.Show($"{trash.Amount} - {trash.Units} - {trash.Category}\n{trash.Description}\n" +
				$"{trash.ResponsiblePerson}\n{trash.CompanyId}\n{trash.RegisterTimeStamp}");			
		}
	}
}
