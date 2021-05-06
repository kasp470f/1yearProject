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
		private Trash openedObject { get; set; }
		public ChangeDataWindow(Trash openedObject)
		{
			InitializeComponent();
			this.openedObject = openedObject;

			//SqlQueries.EditTrashInDb(Id);
		}

		// Opens the DateTimePicker upon click
		private void DateTimePickField_Click(object sender, RoutedEventArgs e) => DateTimePickField.IsOpen = true;

		private void ChangeData_Click(object sender, RoutedEventArgs e)
		{

		}

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
