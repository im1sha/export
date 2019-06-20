using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Demo.Web.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("PersonDB")
        {
        }

        public DbSet<Person> People { get; set; }

    }
    public class PersonInitializer : DropCreateDatabaseIfModelChanges<PersonContext>
    {
        protected override void Seed(PersonContext context)
        {
            var people = new List<Person>()
            {
                new Person{ Name="User1",Surname="Teste1" },
                new Person{ Name="User2",Surname="Teste2" }
            };

            people.ForEach(p => context.People.Add(p));
            context.SaveChanges();
        }

    }


}