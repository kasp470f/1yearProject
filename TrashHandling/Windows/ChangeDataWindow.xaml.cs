using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TrashHandling.Models;


namespace TrashHandling.Windows
{
	/// <summary>
	/// Interaction logic for ChangeDataPopup.xaml
	/// </summary>
	public partial class ChangeDataWindow : Window
	{
		public ChangeDataWindow(Trash openedObject)
		{
			InitializeComponent();
			TrashPicker.ItemsSource = Enum.GetValues(typeof(ComboBoxSources.Categories));
			TrashPicker.SelectedIndex = openedObject.Category - 1;
			UnitPicker.ItemsSource = Enum.GetValues(typeof(ComboBoxSources.Unit));
			UnitPicker.SelectedIndex = openedObject.Units - 1;
			Amount.Text = openedObject.Amount.ToString();
			Description.Text = openedObject.Description;
			Registrator.Text = openedObject.ResponsiblePerson;
			CompanyID.Text = openedObject.CompanyId.ToString();
			DateTimePickField.Text = openedObject.RegisterTimeStamp.ToString();

			//SqlQueries.EditTrashInDb(Id);
		}

		// Opens the DateTimePicker upon click
		private void DateTimePickField_Click(object sender, RoutedEventArgs e) => DateTimePickField.IsOpen = true;

		private void ChangeData_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
