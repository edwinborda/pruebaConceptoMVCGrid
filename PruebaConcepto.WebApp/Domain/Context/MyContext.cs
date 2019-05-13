using PruebaConcepto.WebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaConcepto.WebApp.Domain.Context
{
    public class MyContext : DbContext
    {
        public MyContext()
            :base("name=connString")
        {

        }

        public DbSet<User> User { get; set; }

        public DbSet<Permission> Permission { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<Neighboorhood> Neighboorhood { get; set; }
    }
}