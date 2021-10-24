using MVC_GRID.Models;
using MVC_GRID.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_GRID.Controllers
{
    public class GridController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Grid
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var model = db.Users.ToList();
            return View(model);
        }
        
        public ActionResult Create()
        {
            List<SelectListItem> country = (from i in db.Countries.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.Name,
                                                Value = i.Id.ToString()
                                            }).ToList();
            ViewBag.countryList = country;
            return View();
        }

        [HttpPost]
        public ActionResult Create(User model)
        {
            var country = db.Countries.Where(m => m.Id == model.Country.Id).FirstOrDefault();
            model.Country = country;
            db.Users.Add(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var user = db.Users.Where(m => m.Id == id).FirstOrDefault();
            List<SelectListItem> country = (from i in db.Countries.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.Name,
                                                Value = i.Id.ToString()
                                            }).ToList();
            ViewBag.countryList = country;
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {
            var user = db.Users.Where(m => m.Id == model.Id).FirstOrDefault();
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Age = model.Age;
            var country = db.Countries.Where(m => m.Id == model.Country.Id).FirstOrDefault();
            user.Country= country;
            db.SaveChanges();           
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id!=null)
            {
                var user = db.Users.Where(m => m.Id == id).FirstOrDefault();
                if (user!=null)
                {
                    db.Users.Remove(user);

                    int value = db.SaveChanges();
                    if (value>0)
                    {

                    }
                    else
                    {

                    }
                }
            }
            return View();
        }
    }
}