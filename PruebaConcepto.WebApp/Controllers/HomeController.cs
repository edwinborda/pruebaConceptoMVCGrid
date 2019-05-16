using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Authorization.Mvc;
using Newtonsoft.Json;
using PruebaConcepto.Validations;
using PruebaConcepto.WebApp.Domain.Entities;
using PruebaConcepto.WebApp.Domain.Services;
using PruebaConcepto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PruebaConcepto.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Users> usermanager;
        private readonly IValidate<UserModel> validator;
        public HomeController(IValidate<UserModel> validator)
        {
            usermanager = new UserManager<Users>(new userServices());
            this.validator = validator;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public PartialViewResult IndexGrid()
        {
            var list = new userServices().getAllUser().Select(toUserModel);

            return PartialView("_IndexGrid", list);
        }

        [Authorize]
        [HttpGet]
        public PartialViewResult IndexGrid_()
        {
            var list = new userServices().getAllUser().Select(toUserModel);

            return PartialView("_IndexGrid_", list);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Editar(string id)
        {
            var item = new userServices().getAllUser()
                .Select(toUserModel).FirstOrDefault(p => p.Id == id);

            if (item == null)
                return RedirectToAction("Index");

            return View(item);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Editar(UserModel model)
        {
            if (!validator.RunValidate(model, out var errors))
            {
                ViewBag.Errors = errors.Replace("-", @"\n");
                return View(model);
            }

            var result = new userServices().editUser(toUser(model));
            if (result)
                return new HttpStatusCodeResult(500);

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public PartialViewResult LoginUser()
        {
            var userlist = new userServices().getAllUser();

            ViewBag.UserList = userlist.Select(p => {
                return new SelectListItem()
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                };
            });


            return PartialView("_changeLoginUser");
        }

        [Authorize]
        [HttpPost]
        public ActionResult LoginUser(string UserLogin)
        {
            var user = new userServices().getAllUser("Permissions").FirstOrDefault(p => p.Id == UserLogin);
            TempData["Permissions"] = user.Permissions;


            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public ActionResult getPermission()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var username = identity.Claims.FirstOrDefault(it => it.Type == ClaimTypes.NameIdentifier).Value;
            var permissions = new userServices().getAllUser("Permissions").FirstOrDefault(p => p.UserName == username)?.Permissions;
            var stringPermission = JsonConvert.SerializeObject((IEnumerable<Permission>)permissions);

            return Json(stringPermission, JsonRequestBehavior.AllowGet);
        }

        [ResourceAuthorize(Policy = "IsEditable")]
        [HttpGet]
        public ActionResult Dropdown()
        {
            ViewBag.Deparments = new cityServices().getDepartments().Select(p => {
                return new SelectListItem()
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                };
            });

            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetCities(int id)
        {
            var cities = new cityServices().getCities(id).Select(p => {
                return new SelectListItem()
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                };
            });

            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetNeighboorhoods(int id)
        {
            var neighboorhoods = new cityServices().getNeighboorhood(id).Select(p => {
                return new SelectListItem()
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                };
            });

            return Json(neighboorhoods, JsonRequestBehavior.AllowGet);
        }

        private UserModel toUserModel(Users entity)
        {
            return new UserModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                LastName = entity.LastName,
                Email = entity.Email,
                Phone = entity.PhoneNumber,
                IsEditable = entity.IsEditable,
                UserName = entity.UserName
            };
        }

        private Users toUser(UserModel model)
        {
            return new Users(model.UserName, model.Password, model.Name, model.LastName, model.Email, model.Phone, model.Id.ToString());
        }
    }
}