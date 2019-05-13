using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaConcepto.WebApp.Domain.Entities
{
    [Table("Ciudades")]
    public class City
    {
        internal City()
        {

        }

        public City(string name, string description, int departmentId)
        {
            Name = name;
            Description = description;
            DepartmentId = departmentId;
        }

        public City(string name, string description, Department department)
        {
            Name = name;
            Description = description;
            Department = department;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public int DepartmentId { get; private set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; private set; }
    }
}