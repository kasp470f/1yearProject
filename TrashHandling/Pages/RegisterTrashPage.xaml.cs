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
		//enum for the unitpicker
		private enum Unit
		{			
			Kg = 1,
			Meter = 2,
			Colli = 3
		};

		//list for the category picker
		private List<string> Categories = new()
		{	
			"Batterier",
			"Biler",
			"Elektronikaffald",
			"Imprægneret træ",
			"Inventar",
			"Organisk affald",
			"Pap og papir",
			"Plastemballager",
			"PVC"
		};

		//list for the hour picker
		private List<string> RegisterHour = new()
		{
			"00","01","02","03","04","05","06","07","08","09","10","11",
			"12","13","14","15","16","17","18","19","20","21","22","23"
		};

		//list for the hour picker
		private List<string> RegisterMinute = new()
		{
			"00","05","10","15","20","25","30","35","40","45","50","55"
		};

		public RegisterTrashPage()
		{
			InitializeComponent();
			TrashPicker.ItemsSource = Categories;
			TrashPicker.SelectedItem = Categories[0];

			UnitPicker.Items.Add(Unit.Kg);
			UnitPicker.Items.Add(Unit.Meter);
			UnitPicker.Items.Add(Unit.Colli);

			HourPicker.ItemsSource = RegisterHour;
			HourPicker.SelectedItem = DateTime.Now.ToString("HH");

			MinutePicker.ItemsSource = RegisterMinute;
			
			MinutePicker.SelectedItem = RegisterMinute[0];

			DatePickField.SelectedDate = DateTime.Now;
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
				RegisterTimeStamp = $"{DatePickField.SelectedDate.Value:yyyy:MM:dd} {HourPicker.SelectedItem}:{MinutePicker.SelectedItem}"
			};

			//Call the method to add to the db
			SqlQueries.InsertTrashToDb(trash);

			MessageBox.Show($"{trash.Amount} - {trash.Units} - {trash.Category}\n{trash.Description}\n" +
				$"{trash.ResponsiblePerson}\n{trash.CompanyId}\n{trash.RegisterTimeStamp}");			
		}
	}
}
