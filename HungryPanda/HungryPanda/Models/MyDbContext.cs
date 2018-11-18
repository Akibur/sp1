using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HungryPanda.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public DbSet<Admin> Admins { get; set; }


    }
}
