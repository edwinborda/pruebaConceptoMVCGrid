
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaConcepto.WebApp.Domain.Entities
{
    [Table("Usuarios")]
    public class User
    {
        internal User()
        {

        }
        public User(string name, string lastname, string email, string phone, int id = 0, params Permission[] permissions)
        {
            Name = name;
            LastName = lastname;
            Email = email;
            Phone = phone;
            addPermissions(permissions);

            if (id > 0)
            {
                Id = id;
            }
        }
        public User(string name, string lastname, string email, string phone, params Permission[] permissions)
        {
            Name = name;
            LastName = lastname;
            Email = email;
            Phone = phone;
            addPermissions(permissions);
        }

        public int Id { get; set; }

        public string Name { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; set; }

        public string Phone { get; private set; }
        
        [InverseProperty("Users")]
        public virtual ICollection<Permission> Permissions { get; private set; }

        public bool IsEditable { get; set; } = true;

        private void addPermissions(Permission[] permissions)
        {
            Permissions = permissions.ToList();
        }
    }
}