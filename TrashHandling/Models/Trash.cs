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
		public int Units { get; set; }
		public string Category { get; set; }
		public string Description { get; set; }
		public string ResponsiblePerson { get; set; }
		public int CompanyId { get; set; }
		public string RegisterTimeStamp { get; set; }
	}
}
