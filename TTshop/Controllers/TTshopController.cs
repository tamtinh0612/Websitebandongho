using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TTshop.Controllers
{
    public class TTshopController : Controller
    {
        // GET: TTshop
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SilderPartial()
        {

            return PartialView();
        }
    }
}