﻿using System;
using System.Windows;
using System.Windows.Controls;
using TrashHandling.Models;

namespace TrashHandling.Pages
{
	/// <summary>
	/// Interaction logic for RegisterTrashPage.xaml
	/// <para>Created by Martin</para>
	/// </summary>
	public partial class RegisterTrashPage : Page
	{
		public RegisterTrashPage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Adds data to the Database
		/// <para>Created by Martin</para>
		/// </summary>
		private void AddData_Click(object sender, RoutedEventArgs e)
		{
			//Makes a new Trash object and adds the content from the textboxes and comboboxes on RegisterTrashPage.
			Trash trash = new()
			{
				//Id autogenerates in database...
				Amount = decimal.Parse(Amount.Text),
				Unit = UnitPicker.SelectedIndex + 1,
				Category = TrashPicker.SelectedIndex + 1,
				Description = Description.Text,
				ResponsiblePerson = Responsible.Text,
				CompanyId = int.Parse(CompanyID.Text),
				RegisterTimeStamp = $"{DateTimePickField.Value:yyyy:MM:dd HH:mm}"
			};

			//Call the method to add to the db
			SqlQueries.InsertTrashToDb(trash);

			// Refresh page
			DisplayDataPage.DisplayWindow.RefreshDataGrid();
			ResetFields();

			Console.Log($"A trash element has been added: {trash}");		
		}

		/// <summary>
		/// Resets the fields of the registration page.
		/// <para>Created by Kasper</para>
		/// </summary>
		private void ResetFields()
        {
			Amount.Text = string.Empty;
			UnitPicker.SelectedItem = null;
			TrashPicker.SelectedIndex = 0;
			Description.Text = string.Empty;
			Responsible.Text = string.Empty;
			CompanyID.Text = string.Empty;
			DateTimePickField.Text = string.Empty;
		}

		/// <summary>
		/// Opens the DateTimePicker upon click
		/// <para>Created by Kasper</para>
		/// </summary>
		private void DateTimePickField_Click(object sender, RoutedEventArgs e) => DateTimePickField.IsOpen = true;

		/// <summary>
		/// Loads the CompanyID and Responsible person
		/// <para>Created by Kasper</para>
		/// </summary>
		private void Page_Loaded(object sender, RoutedEventArgs e)
        {
			Responsible.Text = Company.Instance.Name;
			CompanyID.Text = Company.Instance.Id.ToString();
		}
    }
}
