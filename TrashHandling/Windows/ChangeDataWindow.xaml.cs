using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TrashHandling.Models;
using TrashHandling.Pages;

namespace TrashHandling.Windows
{
	/// <summary>
	/// Interaction logic for ChangeDataWindow.xaml
	/// </summary>
	/// <param name="openedObject">The Trash object selected in the DataGrid on DisplayDataPage</param>
	public partial class ChangeDataWindow : Window
	{
		private Trash openedObject { get; set; }
		public ChangeDataWindow(Trash openedObject)
		{
			InitializeComponent();
			this.openedObject = openedObject;			
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
			openedObject = new()
			{
				Id = openedObject.Id,
				Amount = decimal.Parse(Amount.Text),
				Unit = UnitPicker.SelectedIndex + 1,
				Category = TrashPicker.SelectedIndex + 1,
				Description = Description.Text,
				ResponsiblePerson = Registrator.Text,
				CompanyId = int.Parse(CompanyID.Text),
				RegisterTimeStamp = $"{DateTimePickField.Value:yyyy:MM:dd HH:mm}"
			};
			SqlQueries.EditTrashInDb(openedObject);

			DisplayDataPage.DisplayWindow.RefreshDataGrid();
			this.Close();

		}

		/// <summary>
		/// Adds the date after the page is rendered in order to work with the loaded comboboxes.
		/// <para>Created by Kasper</para>	
		/// </summary>
		private void DataRendered(object sender, EventArgs e)
        {
			TrashPicker.SelectedIndex = openedObject.Category - 1;
			UnitPicker.SelectedIndex = openedObject.Unit - 1;

			Amount.Text = openedObject.Amount.ToString();
			Description.Text = openedObject.Description;
			Registrator.Text = openedObject.ResponsiblePerson;
			CompanyID.Text = openedObject.CompanyId.ToString();
			DateTimePickField.Text = openedObject.RegisterTimeStamp.ToString();
        }
    }
}
