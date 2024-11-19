using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KT0720_64130758.Models;

namespace KT0720_64130758.Controllers
{
    public class AccessController : Controller
    {
        KT0720_64130758 db = new KT0720_64130758();
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }
    }
}