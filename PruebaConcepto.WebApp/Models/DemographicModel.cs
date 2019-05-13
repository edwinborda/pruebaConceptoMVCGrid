using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaConcepto.WebApp.Models
{
    public class DemographicModel
    {
        public IEnumerable<SelectListItem> Departments { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }

        public IEnumerable<SelectListItem> Neighborhoods { get; set; }

        [Required]
        public int SelectedDepartment { get; set; }

        [Required]
        public int SelectedCities{ get; set; }

        [Required]
        public int SelectedNeigh { get; set; }
    }
}