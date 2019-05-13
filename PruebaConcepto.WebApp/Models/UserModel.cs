using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaConcepto.WebApp.Models
{
    public class UserModel
    {
        public string Id { get; set; }

        [Display(Name="Nombre")]
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        public bool IsEditable { get; set; }
    }
}