using DataStructures;
using System.Collections.Generic;
using System.Data.Entity;

namespace Demo.Web.Models
{
    public class PersonInitializer : DropCreateDatabaseIfModelChanges<PersonContext>
    {
        protected override void Seed(PersonContext context)
        {
            var people = new List<Person>()
            {
                new Person() { Name = "User 1", Surname = "Test 1" },
                new Person() { Name = "User 2", Surname = "Test 2" }
            };

            people.ForEach(p => context.People.Add(p));
            context.SaveChanges();
        }

    }
}