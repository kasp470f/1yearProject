using System.Collections.Generic;
using System.Linq;

namespace TrashHandling.Models
{
    /// <summary>
    /// <para>Created by Martin</para>
    /// </summary>
    public static class ComboBoxSources
	{
        /// <summary>
        /// Enum for the unitpicker
        /// <para>Created by Martin</para>
        /// </summary>
        public enum Units
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

        /// <summary>
        /// Dictionary for the category picker
        /// <para>Created by Kasper</para>
        /// </summary>
        public static Dictionary<int, string> Categories { get => categories; }
        public static List<string> CategoriesValues { get => categories.Values.ToList(); }
        private static readonly Dictionary<int, string> categories = new()
        {
            { 1, "Batterier" },
            { 2, "Biler" },
            { 3, "Elektronikaffald" },
            { 4, "Imprægneret træ" },
            { 5, "Inventar" },
            { 6, "Organisk affald" },
            { 7, "Pap og papir" },
            { 8, "Plastemballager"},
            { 9, "PVC" },
        };
    }
}
