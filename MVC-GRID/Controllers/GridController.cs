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
    }
}