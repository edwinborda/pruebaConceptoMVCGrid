using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaConcepto.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "No es posible iniciar sesion")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "No es posible iniciar sesion")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}