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
			Colli = 1,
			Stk = 2,
			Ton = 3,
            Kilogram = 4,
            Gram = 5,
            M3 = 6,
            Liter = 7,
            Hektoliter = 8
		};

        // Enum for the category picker
        public enum Categories
        {
            Batterier  = 1,
            Biler = 2,
            Elektronikaffald = 3,
            Imprægneret_træ = 4,
            Inventar = 5,
            Organisk_affald = 6,
            Pap_og_papir = 7,
            Plastemballager = 8,
            PVC = 9
        }
    }
}
