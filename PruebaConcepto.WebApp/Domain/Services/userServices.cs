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
    public class userServices: IUserStore<Users>
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
            myContext.Entry(entity).State = EntityState.Modified;

            return myContext.SaveChanges() > 1;
        }

        public Task CreateAsync(Users user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Users user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Users user)
        {
            throw new NotImplementedException();
        }

        public Task<Users> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Users> FindByNameAsync(string userName)
        {
            return Task.FromResult<Users>(myContext.Users.FirstOrDefault(it => it.UserName == userName));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}