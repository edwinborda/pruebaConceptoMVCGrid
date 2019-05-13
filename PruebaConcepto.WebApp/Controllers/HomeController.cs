using Newtonsoft.Json;
using PruebaConcepto.WebApp.Domain.Entities;
using PruebaConcepto.WebApp.Domain.Services;
using PruebaConcepto.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaConcepto.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult IndexGrid()
        {
            var list = new userServices().getAllUser().Select(toUserModel);

            return PartialView("_IndexGrid", list);
        }

        [HttpGet]
        public PartialViewResult IndexGrid_()
        {
            var list = new userServices().getAllUser().Select(toUserModel);

            return PartialView("_IndexGrid_", list);
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            var item = new userServices().getAllUser()
                .Select(toUserModel).FirstOrDefault(p=>p.Id == id);

            if (item == null)
                return RedirectToAction("Index");

            return View(item);
        }

        [HttpPost]
        public ActionResult Editar(UserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = new userServices().editUser(toUser(model));

            if (result)
                return new HttpStatusCodeResult(500);

            return View(model);
        }

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

        [HttpPost]
        public ActionResult LoginUser(int UserLogin)
        { 
            var user = new userServices().getAllUser("Permissions").FirstOrDefault(p=>p.Id == UserLogin);
            TempData["Permissions"] = user.Permissions;
            

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult getPermission()
        {
            var stringPermission = JsonConvert.SerializeObject((IEnumerable<Permission>)TempData["Permissions"]);
            TempData.Keep("Permission");
            return Json(stringPermission, JsonRequestBehavior.AllowGet);
        }

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

        private UserModel toUserModel(User entity)
        {
            return new UserModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                LastName = entity.LastName,
                Email = entity.Email,
                Phone = entity.Phone,
                IsEditable = entity.IsEditable
            };
        }

        private User toUser(UserModel model)
        {
            return new User(model.Name, model.LastName, model.Email, model.Phone, model.Id);
        }
    }
}