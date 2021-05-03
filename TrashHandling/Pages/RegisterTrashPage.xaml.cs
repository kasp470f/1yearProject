﻿using System;
using System.Collections.Generic;
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
			LoadComboBoxes();
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
				Units = UnitPicker.SelectedIndex + 1,
				Category = TrashPicker.SelectedItem.ToString(),
				Description = Description.Text,
				ResponsiblePerson = Registrator.Text,
				CompanyId = int.Parse(CompanyID.Text),
				RegisterTimeStamp = $"{DateTimePickField.Value:yyyy:MM:dd HH:mm}"
			};

			//Call the method to add to the db
			SqlQueries.InsertTrashToDb(trash);

			Console.Log($"A trash element has been added: {trash.Amount} - {trash.Units} - {trash.Category}\n{trash.Description}\n" +
				$"{trash.ResponsiblePerson}\n{trash.CompanyId}\n{trash.RegisterTimeStamp}");		
		}

		/// <summary>
		/// The Method that will load the comboboxes.
		/// <para>Created by Martin</para>
		/// </summary>
		private void LoadComboBoxes()
		{
			TrashPicker.ItemsSource = ComboBoxSources.Categories;
			TrashPicker.SelectedItem = ComboBoxSources.Categories[0];
			// Adds all enum values through the GetValues() method.
			UnitPicker.ItemsSource = Enum.GetValues(typeof(ComboBoxSources.Unit));
		}

		/// <summary>
		/// Opens the DateTimePicker upon click
		/// <para>Created by Kasper</para>
		/// </summary>
		private void DateTimePickField_Click(object sender, RoutedEventArgs e) => DateTimePickField.IsOpen = true;
	}
}
