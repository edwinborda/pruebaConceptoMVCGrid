
using PruebaConcepto.WebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PruebaConcepto.WebApp.Domain.Context
{
    public class AccountDbContext 
    {
        //public AccountDbContext()
        //    : base("name=connString")
        //{

        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder); 

        //    modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
        //    modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
        //    modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        //}
    }
}