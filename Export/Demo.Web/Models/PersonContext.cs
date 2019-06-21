using DataStructures;
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
   


}