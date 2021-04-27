using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace TrashHandling.Pages
{
	/// <summary>
	/// Interaction logic for RegisterTrash.xaml
	/// </summary>
	public partial class RegisterTrash : Page
	{
		public RegisterTrash()
		{
			InitializeComponent();
			
		List<string> Categories = new()
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
			TrashPicker.ItemsSource = Categories;

			UnitPicker.Items.Add(U.colli);
			UnitPicker.Items.Add(U.kg);
			UnitPicker.Items.Add(U.stk);

			DatePickField.SelectedDate = DateTime.Now;
		}

		public enum U
		{
			colli,
			kg,
			stk
		};
	}
}
