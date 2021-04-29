using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashHandling.Models
{
	public static class ComboBoxSources
	{
		//enum for the unitpicker
		public enum Unit
		{
			Kg = 1,
			Meter = 2,
			Colli = 3
		};

		//list for the category picker
		public static List<string> Categories = new()
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
	}
}
