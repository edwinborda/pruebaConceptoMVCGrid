using PruebaConcepto.WebApp.Domain.Context;
using PruebaConcepto.WebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaConcepto.WebApp.Domain.Services
{
    public class userServices
    {
        private readonly MyContext myContext;
        public userServices()
        {
            this.myContext = new MyContext();
        }

        public IEnumerable<User> getAllUser(string include = null)
        {
            return new List<User>();
            //return string.IsNullOrEmpty(include) ? myContext.User.ToList(): myContext.User.Include(include).ToList();
        }

        public bool addUser(User entity)
        {
            myContext.User.Add(entity);

            return myContext.SaveChanges() > 1;
        }

        public bool editUser(User entity)
        {
            myContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            return myContext.SaveChanges() > 1;
        }
    }
}