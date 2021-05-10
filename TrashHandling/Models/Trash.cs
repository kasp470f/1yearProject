using System;
using System.Data.SqlTypes;
using System.Globalization;
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
        
        public string DateTimePickerValue { 
            get {
                string[] spaceSplit = RegisterTimeStamp.Split(' ');
                string[] colonSplit = new string[5] { spaceSplit[0].Split(':')[0], spaceSplit[0].Split(':')[1], spaceSplit[0].Split(':')[2], spaceSplit[1].Split(':')[0], spaceSplit[1].Split(':')[1] };
                return $"{colonSplit[0]}-{colonSplit[1]}-{colonSplit[2]} {colonSplit[3]}:{colonSplit[4]}";
            }
        }

        //Display Text
        public string CategoryText { get => Categories[Category]; }
        public string UnitsText { get => Enum.GetName(typeof(Units), Unit); }
        public string IdText { get; set; }

        /// <summary>
        /// An overridden function to write out the element.
        /// <para>Created by Kasper</para>
        /// </summary>
        /// <returns>A string with all the properties</returns>
        public override string ToString()
        {
            return $"{Id},{Amount},{Unit},{Category},{Description},{ResponsiblePerson},{CompanyId},{RegisterTimeStamp}";
        }
    }
}
