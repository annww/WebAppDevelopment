using BaiTap2_64130758.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace BaiTap2_64130758.Controllers
{
    public class SinhVien_64130758Controller : Controller
    {
        // GET: SinhVien_64130758
        public ActionResult Index()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Index2(FormCollection field)
        {
            ViewBag.Id = field["Id"];
            ViewBag.Name = field["Name"];
            ViewBag.Marks = field["Marks"];
            return PartialView(ViewBag);
        }
        public ActionResult UseAction()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult UseAction1(FormCollection field)
        {
            ViewBag.Id = Request["Id"];
            ViewBag.Name = Request["Name"];
            ViewBag.Marks = Request["Marks"];
            return PartialView(ViewBag);
        }
        public ActionResult Index3()
        {
            return PartialView();
        }
        public ActionResult Register3(string Id, string Name, string Marks)
        {
            ViewBag["id"] = Id;
            ViewBag["name"] = Name;
            ViewBag.Marks = Marks;
            return PartialView(ViewBag);
        }
        public ActionResult Index4()
        {
            return PartialView();
        }
        public ActionResult Index5(Students st)
        {
            ViewBag.Id = st.Id;
            ViewBag.Name = st.Name;
            ViewBag.Marks = st.Marks;
            return PartialView(ViewBag);
        }
    }
}