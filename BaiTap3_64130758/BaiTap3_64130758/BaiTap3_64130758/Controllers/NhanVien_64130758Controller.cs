﻿using BaiTap3_64130758.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap3_64130758.Controllers
{
    public class NhanVien_64130758Controller : Controller
    {
        public ActionResult Index()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase Avatar, EmpModel emp)
        {
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(Avatar.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Images/" + postedFileName);
            Avatar.SaveAs(path);
            string fSave = Server.MapPath("/emp.txt");
            string[] emInfo =
           {emp.EmpID, emp.Name, emp.BirthOfDate.ToShortDateString(),
            emp.Email,emp.Password,emp.Department, postedFileName};
            //Lưu các thông ti vào tập tin emp.txt
            System.IO.File.WriteAllLines(fSave, emInfo);
            //Ghi nhận các thông tin đăng ký để hiện thị trên View Confirm
            ViewBag.EmpID = emInfo[0];
            ViewBag.Name = emInfo[1];
            ViewBag.BirthOfDate = emInfo[2].ToString();
            ViewBag.Email = emInfo[3];
            ViewBag.Password = emInfo[4];
            ViewBag.Department = emInfo[5];
            ViewBag.Avatar = "/Images/" + emInfo[6];
            return View("Confirm");
        }
        public ActionResult Confirm()
        {
            return View();
        }
    }
}