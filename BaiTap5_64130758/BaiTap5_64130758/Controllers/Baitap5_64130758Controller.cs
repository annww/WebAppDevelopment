using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap5_64130758.Controllers
{
    public class BaiTap5_64130758Controller : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeBanner()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeBanner(HttpPostedFileBase banner)
        {
            string postedFileName =
                System.IO.Path.GetFileName(banner.FileName);
            var path = Server.MapPath("/Image/" + postedFileName);
            banner.SaveAs(path);
            string fSave = Server.MapPath("/banner.txt");
            System.IO.File.WriteAllText(fSave, postedFileName);
            return View();
        }
    }
}
