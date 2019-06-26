using DataStructures;
using System.Data.Entity;

namespace Demo.Web.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("PersonDB")
        {
        }

        public DbSet<Person> People { get; set; }

    }
}

