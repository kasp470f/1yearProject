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
        public string LocalID { get; set; }
        public int Id { get; set; }
		public decimal Amount { get; set; }
		public int Units { get; set; }
        public string UnitsText { get => Enum.GetName(typeof(Unit), Units); }
		public string Category { get; set; }
        public string Description { get; set; }
		public string ResponsiblePerson { get; set; }
		public int CompanyId { get; set; }
		public string RegisterTimeStamp { get; set; }


        /// <summary>
        /// A overriden function to write out the element.
        /// <para>Created by Kasper</para>
        /// </summary>
        /// <returns>A string with all the properties</returns>
        public override string ToString()
        {
            return $"{Id},{Amount},{Units},{Category},{Description},{ResponsiblePerson},{CompanyId},{RegisterTimeStamp}";
        }
    }
}
