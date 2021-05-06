using System;
using static TrashHandling.Models.ComboBoxSources;

namespace TrashHandling.Models
{
    /// <summary>
    /// The class object containing the properties to handle trash
    /// <para>Created by Martin</para>
    /// </summary>
    public class Trash
	{
        public int Id { get; set; }
        public decimal Amount { get; set; }
		public int Unit { get; set; }
		public int Category { get; set; }
        public string Description { get; set; }
		public string ResponsiblePerson { get; set; }
		public int CompanyId { get; set; }
		public string RegisterTimeStamp { get; set; }

        //Display Text
        public string CategoryText { get => ComboBoxSources.Categories[Category]; }
        public string UnitsText { get => Enum.GetName(typeof(Units), Unit); }
        public string IdText { get; set; }

        /// <summary>
        /// A overriden function to write out the element.
        /// <para>Created by Kasper</para>
        /// </summary>
        /// <returns>A string with all the properties</returns>
        public override string ToString()
        {
            return $"{Id},{Amount},{Unit},{Category},{Description},{ResponsiblePerson},{CompanyId},{RegisterTimeStamp}";
        }
    }
}
