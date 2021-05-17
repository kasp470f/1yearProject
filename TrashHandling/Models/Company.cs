using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashHandling.Models
{
    /// <summary>
    /// A class that holds the account information from the login page.
    /// <para>Created by Kasper</para>
    /// </summary>
	public class Company
	{ 
		public string Name { get => name; }
		private string name;

		public int Id { get => id; }
		private int id;

        public Company(string name, int id)
        {
            if (instance == null)
            {
                this.name = name;
                this.id = id;
                instance = this;
            }
        }

        private static Company instance;
        public static Company Instance
        {
            get
            {
                return instance;
            }
        }

        public static Company RemoveInstance
        {
            set
            {
                instance = null;
            }
        }
    }
}
