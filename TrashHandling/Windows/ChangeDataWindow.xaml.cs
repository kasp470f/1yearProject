using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TrashHandling.Models;
using TrashHandling.Pages;
using Console = TrashHandling.Pages.Console;

namespace TrashHandling.Windows
{
	/// <summary>
	/// Interaction logic for ChangeDataWindow.xaml
	/// </summary>
	/// <param name="openedObject">The Trash object selected in the DataGrid on DisplayDataPage</param>
	public partial class ChangeDataWindow : Window
	{
		private Trash OpenedObject { get; set; }
		public ChangeDataWindow(Trash openedObject)
		{
			InitializeComponent();
			this.OpenedObject = openedObject;			
		}

		/// <summary>
		/// Opens the DateTimePicker upon click
		/// <para>Created by Kasper</para>
		/// </summary>
		private void DateTimePickField_Click(object sender, RoutedEventArgs e) => DateTimePickField.IsOpen = true;

		/// <summary>
		/// Calls the Sql-query to update the openedObject
		/// <para>Created by Martin</para>		
		/// </summary>
		private void ChangeData_Click(object sender, RoutedEventArgs e)
		{
			OpenedObject = new()
			{
				Id = OpenedObject.Id,
				Amount = decimal.Parse(Amount.Text),
				Unit = UnitPicker.SelectedIndex + 1,
				Category = TrashPicker.SelectedIndex + 1,
				Description = Description.Text,
				ResponsiblePerson = Registrator.Text,
				CompanyId = int.Parse(CompanyID.Text),
				RegisterTimeStamp = $"{DateTimePickField.Value:yyyy:MM:dd HH:mm}"
			};
			SqlQueries.EditTrashInDb(OpenedObject);

			Console.Log($"A trash element has been edited: {OpenedObject}");
			DisplayDataPage.DisplayWindow.RefreshDataGrid();
			this.Close();

		}

		/// <summary>
		/// Adds the date after the page is rendered in order to work with the loaded comboboxes.
		/// <para>Created by Kasper</para>	
		/// </summary>
		private void DataRendered(object sender, EventArgs e)
        {
			TrashPicker.SelectedIndex = OpenedObject.Category - 1;
			UnitPicker.SelectedIndex = OpenedObject.Unit - 1;

			Amount.Text = OpenedObject.Amount.ToString();
			Description.Text = OpenedObject.Description;
			Registrator.Text = OpenedObject.ResponsiblePerson;
			CompanyID.Text = OpenedObject.CompanyId.ToString();
			DateTimePickField.Text = OpenedObject.RegisterTimeStamp.ToString();
        }
    }
}
