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
			TrashPicker.ItemsSource = ComboBoxSources.Categories;
			TrashPicker.SelectedItem = openedObject.Category;
			Amount.Text = openedObject.Amount.ToString();
			Description.Text = openedObject.Description;
			Registrator.Text = openedObject.ResponsiblePerson;
			CompanyID.Text = openedObject.CompanyId.ToString();
			DateTimePickField.Value = DateTime.Parse(openedObject.RegisterTimeStamp.ToString());

			//SqlQueries.EditTrashInDb(Id);
		}

		// Opens the DateTimePicker upon click
		private void DateTimePickField_Click(object sender, RoutedEventArgs e) => DateTimePickField.IsOpen = true;

		private void ChangeData_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
