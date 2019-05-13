namespace PruebaConcepto.WebApp.Migrations
{
    using PruebaConcepto.WebApp.Domain.Context;
    using PruebaConcepto.WebApp.Domain.Entities;
    using System;
    using System.Collections.Generic;
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
            var departmentsCundi = new Department() { Name = "Cundinamarca", Description = "Departamento de Cundinamarca" };
            var departmentsAnti = new Department() { Name = "Antioquia", Description = "Departamento de Antioquia" };
            var departmentsBoy = new Department() { Name = "Boyaca", Description = "Departamento de Boyaca" };
            var bogota = new City("Bogotá", "Ciudad Capital", departmentsCundi);
            var chia = new City("Chia", "", departmentsCundi);
            var cota = new City("Cota", "", departmentsCundi);
            var funza = new City("Funza", "", departmentsCundi);
            var faca = new City("Facatativa", "", departmentsCundi);
            var medellin = new City("Medellin", "", departmentsAnti);
            var sabaneta = new City("Sabaneta", "", departmentsAnti);
            var urrao = new City("Urrao", "", departmentsAnti);
            var envigado = new City("Envigado", "", departmentsAnti);
            var tunja = new City("Tunja", "", departmentsBoy);
            var villaleyva = new City("Villa de Leyva", "", departmentsBoy);
            var chiquin = new City("Chinquinquira", "", departmentsBoy);
            var raquira = new City("Raquira", "", departmentsBoy);
            var simijaca = new City("Simijaca", "", departmentsBoy);
            context.Department.AddOrUpdate(it => it.Name, departmentsCundi, departmentsAnti, departmentsBoy);
            context.City.AddOrUpdate(it => it.Name,
                bogota,
                chia,
                cota,
                funza,
                faca,
                medellin,
                sabaneta,
                urrao,
                envigado,
                tunja,
                villaleyva,
                chiquin,
                raquira,
                simijaca
            );

            context.Neighboorhood.AddOrUpdate(it => it.Name,
                new Neighboorhood("La castellana", bogota),
                new Neighboorhood("Los Rosales", bogota),
                new Neighboorhood("Nicolas de federman", bogota),
                new Neighboorhood("Chapinero alto", bogota),
                new Neighboorhood("El prado", medellin),
                new Neighboorhood("Ciudad jardin", medellin),
                new Neighboorhood("El poblado", medellin),
                new Neighboorhood("El nogal", medellin),
                new Neighboorhood("Laureles", medellin)
            );

            context.Permission.AddOrUpdate(it => it.Name, permisoAct);
            context.Permission.AddOrUpdate(it => it.Name, permisoCrearRoles);
            context.Users.AddOrUpdate(it => it.Email,
                new Users("eborda","12345", "Edwin", "Borda", "edwin.borda@outlook.com", "3202660453", permisoAct, permisoCrearRoles),
                new Users("joseh", "12345", "Jose", "Hernandez",  "joseh@outlook.com", "0315446789", permisoAct, permisoCrearRoles),
                new Users("pedrop", "12345","Pedro", "Perez", "pedrop@outlook.com", "3107867876", permisoAct, permisoCrearRoles),
                new Users("armpelaez", "12345", "Armando", "Pelaez",  "armpelaez@outlook.com", "3107625676", permisoCrearRoles));


        }
    }
}
