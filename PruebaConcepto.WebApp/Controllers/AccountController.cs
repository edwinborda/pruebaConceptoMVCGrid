using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using PruebaConcepto.WebApp.Domain.Entities;
using PruebaConcepto.WebApp.Domain.Services;
using PruebaConcepto.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace PruebaConcepto.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Users> usermanager;
        public AccountController()
        {
            usermanager = new UserManager<Users>(new userServices());
        }

        // GET: Account
        public ActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            var user = usermanager.FindByName(model.UserName);
            if (user != null)
            {
                if (new PasswordHasher().VerifyHashedPassword(user.PasswordHash, model.Password) == PasswordVerificationResult.Success)
                {
                    var ident = new ClaimsIdentity(
                        new[] {   
                                  new Claim(ClaimTypes.NameIdentifier, model.UserName),
                                  new Claim("IsEditable", user.IsEditable.ToString())
                                  //new Claim(ClaimTypes.Role, "RoleName"),
                                  //new Claim(ClaimTypes.Role, "AnotherRole")
                    },
                    DefaultAuthenticationTypes.ApplicationCookie);

                    HttpContext.GetOwinContext().Authentication.SignIn(
                       new AuthenticationProperties { IsPersistent = false }, ident);
                    return RedirectToAction("Index", "Home");
                }

            }
            return View(model);
        }
    }
}