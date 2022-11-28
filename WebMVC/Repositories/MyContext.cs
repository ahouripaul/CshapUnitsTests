using System;
using System.Data.Entity;
using System.Linq;
using WebMVC.Models;

namespace WebMVC.Repositories
{
    public class MyContext : DbContext
    {
      
        public MyContext()
            : base("name=MyContext")
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }

   
}