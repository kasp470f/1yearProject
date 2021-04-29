using System;
using System.Collections.Generic;
using System.Windows.Controls;

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
			// Adds all enum values through the GetValues() method.
			UnitPicker.ItemsSource = Enum.GetValues(typeof(Unit));
		}
	}
}
