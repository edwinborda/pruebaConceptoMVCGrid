using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PruebaConcepto.WebApp.Domain.Entities
{
    [Table("Barrios")]
    public class Neighboorhood
    {
        internal Neighboorhood()
        {

        }

        public Neighboorhood(string name, int cityid)
        {
            Name = name;
            CityId = cityid;
        }

        public Neighboorhood(string name, City city)
        {
            Name = name;
            City = city;
        }
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int CityId { get; private set; }

        [ForeignKey("CityId")]
        public virtual City City { get; private set; }
    }
}