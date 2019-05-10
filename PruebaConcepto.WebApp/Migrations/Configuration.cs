namespace PruebaConcepto.WebApp.Migrations
{
    using PruebaConcepto.WebApp.Domain.Context;
    using PruebaConcepto.WebApp.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PruebaConcepto.WebApp.Domain.Context.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PruebaConcepto.WebApp.Domain.Context.MyContext context)
        {
            var permisoAct = new Permission("Actualiza usuario", "poder actualizar usuarios");
            var permisoCrearRoles = new Permission("Asociar roles", "asociar Roles");

           context.Permission.AddOrUpdate(it => it.Name, permisoAct);
           context.Permission.AddOrUpdate(it => it.Name, permisoCrearRoles);
           context.User.AddOrUpdate(it => it.Email,
                new User("Edwin", "Borda", "edwin.borda@outlook.com", "3202660453",permisoAct, permisoCrearRoles),
                new User("Jose", "Hernandez", "joseh@outlook.com", "0315446789", permisoAct, permisoCrearRoles),
                new User("Pedro", "Perez", "pedrop@outlook.com", "3107867876", permisoAct, permisoCrearRoles),
                new User("Armando", "Pelaez", "armpelaez@outlook.com", "3107625676", permisoCrearRoles));
        }
    }
}
