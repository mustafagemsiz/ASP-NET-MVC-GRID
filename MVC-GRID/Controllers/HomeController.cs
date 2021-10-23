using MVC_GRID.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_GRID.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();  
        // GET: Home
        public ActionResult Index()
        {
            var value = db.Users.ToList();
            return View();
        }

        public ActionResult List()
        {
            var model = db.Users.ToList();
            return View(model);
        }
    }
}