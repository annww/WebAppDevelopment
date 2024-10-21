using BaiTap5_64130758.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Xml.Schema;

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

        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(HttpPostedFileBase Avatar, EmpModel emp)
        {
            // Lay thong tin 
            string PostedFileName = System.IO.Path.GetFileName(Avatar.FileName);
            // Luu thong tin ve anh dai dien
            var path = Server.MapPath("/Image/" + PostedFileName);
            Avatar.SaveAs(path);
            string fSave = Server.MapPath("/emp.txt");
            string[] empInfo =
            {
                emp.EmpID.ToString(), emp.Name,emp.DOB.ToShortDateString(),
                emp.Email,emp.Password,emp.Department, PostedFileName
            };
            // Luu thong tin trong tep emp
            System.IO.File.WriteAllLines(fSave, empInfo);
            // Ghi nhan cac thong tin dang ky de hien thi tren View Confirm
            ViewBag.EmpID = empInfo[0];
            ViewBag.Name = empInfo[1];
            ViewBag.DOB = empInfo[2].ToString();
            ViewBag.Email = empInfo[3];
            ViewBag.Password = empInfo[4];
            ViewBag.Department = empInfo[5];
            ViewBag.Avatar = "/Image/" + empInfo[6];
            return View("Confirm");
        }
        public ActionResult Confirm()
        {
            return View();
        }
        public ActionResult SendEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendEmail(MailInfo model)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new System.Net.Mail.MailAddress(model.From);
            mail.To.Add(model.To);
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = true;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential(model.From, model.Password);
            smtp.EnableSsl = true;

            smtp.Send(mail);
            return RedirectToAction("SendEmail");
        }

    }
}

