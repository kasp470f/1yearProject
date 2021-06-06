using System;
using System.Windows;
using TrashHandling.Models;
using TrashHandling.Pages;
using Console = TrashHandling.Pages.Console;

namespace TrashHandling.Windows
{
	/// <summary>
	/// Interaction logic for ChangeDataWindow.xaml
	/// <para>Created by Martin</para>
	/// </summary>
	public partial class ChangeDataWindow : Window
	{
		// The Trash object selected in the DataGrid on DisplayDataPage
		private Trash OpenedObject { get; set; }

		/// <summary>
		/// Constructor for the ChangeDataWindow
		/// <para>Created by Martin</para>
		/// </summary>
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
				Unit = (int)Enum.Parse(typeof(ComboBoxSources.Units), UnitPicker.Text),
				Category = TrashPicker.SelectedIndex + 1,
				Description = Description.Text,
				ResponsiblePerson = Registrator.Text,
				CompanyId = int.Parse(CompanyID.Text),
				RegisterTimeStamp = $"{DateTimePickField.Value:yyyy:MM:dd HH:mm}"
			};

			if (MessageBox.Show("Du er ved at ændre denne post. Er det korrekt?", "Advarsel", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
			{
				SqlQueries.EditTrashInDb(OpenedObject);
				Console.Log($"En affalds post er blevet ændret: {OpenedObject}");
				DisplayDataPage.DisplayWindow.RefreshDataGrid();
				this.Close();
			}
		}

		/// <summary>
		/// Adds the date after the page is rendered in order to work with the loaded comboboxes.
		/// <para>Created by Kasper</para>	
		/// </summary>
		private void DataRendered(object sender, EventArgs e)
        {
			TrashPicker.SelectedIndex = OpenedObject.Category - 1;
			UnitPicker.Text = OpenedObject.UnitsText;

			Amount.Text = OpenedObject.Amount.ToString();
			Description.Text = OpenedObject.Description;
			Registrator.Text = OpenedObject.ResponsiblePerson;
			CompanyID.Text = OpenedObject.CompanyId.ToString();
			DateTimePickField.Text = OpenedObject.RegisterTimeStamp.ToString();
        }

		/// <summary>
		/// Shows a Messagebox for delete-confirmation and if yes, calls the Sql-query to delete the openedObject
		/// <para>Created by Martin</para>		
		/// </summary>
		private void DeleteData_Click(object sender, RoutedEventArgs e)
		{
			//An alert will be shown to ask user to be sure
			MessageBoxResult result = MessageBox.Show("Denne post vil blive slettet.\nEr det korrekt?","Advarsel!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
			if (result == MessageBoxResult.Yes)
			{
				Trash obj = OpenedObject;
				OpenedObject = new()
				{
					Id = OpenedObject.Id
				};
				SqlQueries.DeleteTrashFromDb(OpenedObject);
				Console.Log($"{obj} er blevet slettet");
				DisplayDataPage.DisplayWindow.RefreshDataGrid();
				this.Close();
			}			
		}
	}
}
