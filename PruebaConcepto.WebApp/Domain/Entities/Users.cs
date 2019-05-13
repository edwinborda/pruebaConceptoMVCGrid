
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaConcepto.WebApp.Domain.Entities
{
    [Table("dbo.Usuarios")]
    public class Users : IdentityUser
    {
        internal Users()
        {

        }
        public Users(string username, string password, string name, string lastname, string email, string phone, string id = null, params Permission[] permissions)
        {
            UserName = username;
            PasswordHash = new PasswordHasher().HashPassword(password);
            Name = name;
            LastName = lastname;
            Email = email;
            PhoneNumber = phone;
            addPermissions(permissions);

            if (!string.IsNullOrEmpty(id))
                Id = id;
        }
        public Users(string username,string password, string name, string lastname, string email, string phone, params Permission[] permissions)
        {
            UserName = username;
            PasswordHash = new PasswordHasher().HashPassword(password);
            Name = name;
            LastName = lastname;
            Email = email;
            PhoneNumber = phone;
            TwoFactorEnabled = false;
            EmailConfirmed = false;
            PhoneNumberConfirmed = false;
            AccessFailedCount = 0;
            LockoutEnabled = true;
            addPermissions(permissions);
            
        }
        
        public string Name { get; private set; }

        public string LastName { get; private set; }
        
        [InverseProperty("Users")]
        public virtual ICollection<Permission> Permissions { get; private set; }

        public bool IsEditable { get; set; } = true;
        
        private void addPermissions(Permission[] permissions)
        {
            Permissions = permissions.ToList();
        }

    }
}