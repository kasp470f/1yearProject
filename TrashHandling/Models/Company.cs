namespace TrashHandling.Models
{
    /// <summary>
    /// A class that holds the account information from the login page.
    /// <para>Created by Kasper</para>
    /// </summary>
    public class Company
    {
        // Name property
        public string Name { get => name; }
        private string name;

        // Id property
        public int Id { get => id; }
        private int id;

        // Company constructor
        public Company(string name, int id)
        {
            // Only allow one instance
            if (instance == null)
            {
                this.name = name;
                this.id = id;
                instance = this;
            }
        }

        // Company instance property
        private static Company instance;
        public static Company Instance
        {
            get
            {
                return instance;
            }
        }

        // Remove current instance
        public static Company RemoveInstance
        {
            set
            {
                instance = null;
            }
        }
    }
}
