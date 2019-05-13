using PruebaConcepto.WebApp.Domain.Context;
using PruebaConcepto.WebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaConcepto.WebApp.Domain.Services
{
    public class cityServices
    {
        private readonly MyContext myContext;
        public cityServices()
        {
            myContext = new MyContext();
        }

        public IEnumerable<Department> getDepartments()
        {
            return myContext.Department.ToList();
        }

        public IEnumerable<City> getCities(int idDeparment)
        {
            return myContext.City.Where(it => it.DepartmentId == idDeparment).ToList();
        }

        public IEnumerable<Neighboorhood> getNeighboorhood(int idCity)
        {
            return myContext.Neighboorhood.Where(it => it.CityId == idCity).ToList();
        }
    }
}