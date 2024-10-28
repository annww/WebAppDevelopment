using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Thi64CNTTCLC2_64130758.Models;

namespace Thi64CNTTCLC2_64130758.Controllers
{
    public class Sachs_64130758Controller : Controller
    {
        private Thi64CNTTCLC2_64130758Entities1 db = new Thi64CNTTCLC2_64130758Entities1();

        // GET: Sachs_64130758
        public ActionResult Index()
        {
            var saches = db.Saches.Include(s => s.LoaiSach);
            return View(saches.ToList());
        }

        // GET: Sachs_64130758/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // GET: Sachs_64130758/Create
        public ActionResult Create()
        {
            ViewBag.MaLS = new SelectList(db.LoaiSaches, "MaLS", "TenLS");
            return View();
        }

        // POST: Sachs_64130758/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,TenSach,AnhDaiDien,MoTa,DonGia,NgonNgu,TacGia,MaLS")] Sach sach)
        {
            var imgSach = Request.Files["Avatar"];

            // Lấy thông tin từ input type=file có tên Avatar
            if (imgSach != null && imgSach.ContentLength > 0)
            {
                // Lấy tên tệp từ tệp đã tải lên
                string postedFileName = System.IO.Path.GetFileName(imgSach.FileName);
                // Lưu hình đại diện về Server
                var path = Server.MapPath("/images/" + postedFileName);
                imgSach.SaveAs(path);

                // Cập nhật tên ảnh vào đối tượng sach
                sach.AnhDaiDien = postedFileName;
            }

            if (ModelState.IsValid)
            {
                sach.MaSach = LayMaSach(); // Đảm bảo mã sách được sinh tự động
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLS = new SelectList(db.LoaiSaches, "MaLS", "TenLS", sach.MaLS);
            return View(sach);
        }

        string LayMaSach()
        {
            var maMax = db.Saches.ToList().Select(n => n.MaSach).Max();
            int maSach = int.Parse(maMax.Substring(1)) + 1; // Giả sử mã sách bắt đầu từ S1
            string newMaSach = "S" + maSach.ToString("D3");
            return newMaSach;
        }
        // GET: Sachs_64130758/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLS = new SelectList(db.LoaiSaches, "MaLS", "TenLS", sach.MaLS);
            return View(sach);
        }

        // POST: Sachs_64130758/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,TenSach,AnhDaiDien,MoTa,DonGia,NgonNgu,TacGia,MaLS")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLS = new SelectList(db.LoaiSaches, "MaLS", "TenLS", sach.MaLS);
            return View(sach);
        }

        // GET: Sachs_64130758/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach sach = db.Saches.Find(id);
            if (sach == null)
            {
                return HttpNotFound();
            }
            return View(sach);
        }

        // POST: Sachs_64130758/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Sach sach = db.Saches.Find(id);
            db.Saches.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult GioiThieu_64130758()
        {
            return View();
        }

        public ActionResult TimKiem_64130758()
        {
            // Hiển thị toàn bộ sách khi truy cập GET
            var sachList = db.Saches.ToList();
            return View(sachList);
        }

        [HttpPost]
        public ActionResult TimKiem_64130758(string tenSach, string maSach)
        {
            // Kiểm tra nếu cả hai đều rỗng, hiển thị toàn bộ sách
            if (string.IsNullOrEmpty(tenSach) && string.IsNullOrEmpty(maSach))
            {
                var allSach = db.Saches.ToList();
                return View(allSach);
            }

            // Truy vấn sách theo điều kiện tìm kiếm
            var sachTimKiem = db.Saches.AsQueryable();

            if (!string.IsNullOrEmpty(tenSach))
            {
                sachTimKiem = sachTimKiem.Where(s => s.TenSach.Contains(tenSach));
            }

            if (!string.IsNullOrEmpty(maSach))
            {
                sachTimKiem = sachTimKiem.Where(s => s.MaSach.Contains(maSach));
            }

            var resultList = sachTimKiem.ToList();

            // Nếu không tìm thấy, hiển thị thông báo
            if (!resultList.Any())
            {
                ViewBag.Message = "Không có thông tin cần tìm";
            }

            return View(resultList);
        }


    }
}
