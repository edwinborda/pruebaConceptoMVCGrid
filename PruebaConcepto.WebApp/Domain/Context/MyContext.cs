using Microsoft.AspNet.Identity.EntityFramework;
using PruebaConcepto.WebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PruebaConcepto.WebApp.Domain.Context
{
    public class MyContext : IdentityDbContext<Users>
    {
        public MyContext()
            :base("name=connString", throwIfV1Schema: false)
        {

        }

        public static MyContext Create()
        {
            return new MyContext();
        }

        public DbSet<Permission> Permission { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<Neighboorhood> Neighboorhood { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}