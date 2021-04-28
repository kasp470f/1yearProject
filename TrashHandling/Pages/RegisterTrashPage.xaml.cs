using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
		private enum Unit
		{
			colli,
			kg,
			stk
		};

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

		public RegisterTrashPage()
		{
			InitializeComponent();
			TrashPicker.ItemsSource = Categories;

			UnitPicker.Items.Add(Unit.colli);
			UnitPicker.Items.Add(Unit.kg);
			UnitPicker.Items.Add(Unit.stk);

			DatePickField.SelectedDate = DateTime.Now;
		}

		private void AddData_Click(object sender, RoutedEventArgs e)
		{
			Trash trash = new()
			{
				//Id autogenereres i databasen...
				Amount = decimal.Parse(Amount.Text),
				Units = UnitPicker.SelectedItem.ToString(),
				Category = TrashPicker.SelectedItem.ToString(),
				Description = Description.Text,
				ResponsiblePerson = Registrator.Text,
				CompanyId = int.Parse(CompanyID.Text),
				RegisterTimeStamp = $"{DatePickField.SelectedDate.Value:yyyy:MM:dd HH:mm}"
			};

			SqlQueries.InsertTrashToDb(trash);

			MessageBox.Show($"{trash.Amount} - {trash.Units} - {trash.Category}\n{trash.Description}\n" +
				$"{trash.ResponsiblePerson}\n{trash.CompanyId}\n{trash.RegisterTimeStamp}");			
		}
	}
}
