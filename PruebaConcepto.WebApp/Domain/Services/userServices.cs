using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PruebaConcepto.WebApp.Domain.Context;
using PruebaConcepto.WebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PruebaConcepto.WebApp.Domain.Services
{
    public class userServices: IUserStore<IdentityUser>
    {
        private readonly MyContext myContext;
        public userServices()
        {
            this.myContext = new MyContext();
        }

        public IEnumerable<Users> getAllUser(string include = null)
        {
            return string.IsNullOrEmpty(include) ? myContext.Users.ToList(): myContext.Users.Include(include).ToList();
        }

        public bool addUser(Users entity)
        {
            myContext.Users.Add(entity);

            return myContext.SaveChanges() > 1;
        }

        public bool editUser(Users entity)
        {
            myContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            return myContext.SaveChanges() > 1;
        }

        public Task CreateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}