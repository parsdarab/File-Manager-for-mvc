using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileManagerForMvc.DataAccess;

namespace FileManagerForMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product model)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView();
            }
            return View();
        }
    }
}
