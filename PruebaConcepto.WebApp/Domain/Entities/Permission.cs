using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaConcepto.WebApp.Domain.Entities
{
    [Table("Permisos")]
    public class Permission
    {
        internal Permission()
        {

        }

        public Permission(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public int Id { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        [JsonIgnore]
        [InverseProperty("Permissions")]
        public virtual ICollection<Users> Users { get; private set; }
    }
}