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
	public partial class ChangeDataWindow : Window
	{
		private Trash openedObject { get; set; }
		public ChangeDataWindow(Trash openedObject)
		{
			InitializeComponent();
			this.openedObject = openedObject;			
		}

		// Opens the DateTimePicker upon click
		private void DateTimePickField_Click(object sender, RoutedEventArgs e) => DateTimePickField.IsOpen = true;

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
			System.Threading.Thread.Sleep(3000);
			DisplayDataPage pg = new();
			pg.DbDisplayer.ItemsSource = null;
			pg.DbDisplayer.Items.Clear();
			List<Trash> db = SqlQueries.GetTrashFromDb();
			pg.DbDisplayer.ItemsSource = db;
			pg.DbDisplayer.Items.Refresh();
			
			this.Close();
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
