using System.Collections.Generic;

namespace TrashHandling.Models
{
    /// <summary>
    /// A directory for Units and categories
    /// <para>Created by Martin</para>
    /// </summary>
    public static class ComboBoxSources
	{
		// Enum for the unitpicker
		public enum Unit
		{
			Kg = 1,
			Meter = 2,
			Colli = 3
		};

        // List for the category picker
        public static List<string> Categories { get => categories; }
        private static List<string> categories = new()
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
