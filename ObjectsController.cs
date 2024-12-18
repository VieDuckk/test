using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LamLaiTX2Lan2.Models;

namespace LamLaiTX2Lan2.Controllers
{
    public class ObjectsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Objects
        public ActionResult Xemdanhsach(string tim)
        {
            var hocSinhs = db.HocSinhs.Select(h => h);
            if (tim != null)
            {
                hocSinhs =db.HocSinhs.Select(h => h).Where(h =>h.sbd.Contains(tim));
            }
            return View(hocSinhs.ToList());
        }

        // GET: Objects/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocSinh hocSinh = db.HocSinhs.Find(id);
            if (hocSinh == null)
            {
                return HttpNotFound();
            }
            return View(hocSinh);
        }

        // GET: Objects/Create
        public ActionResult ThemDulieu()
        {
            ViewBag.malop = new SelectList(db.LopHocs, "malop", "tenlop");
            return View();
        }

        // POST: Objects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemDulieu([Bind(Include = "sbd,hoten,anhduthi,malop,diemthi")] HocSinh hocSinh)
        {
            if (ModelState.IsValid)
            {
                var f = Request.Files["FileName"];
                if(f != null && f.ContentLength>0)
                {
                    string Tenfile = System.IO.Path.GetFileName(f.FileName);
                    string duongdan = Server.MapPath("~/Images/" + Tenfile);
                    f.SaveAs(duongdan);
                    hocSinh.anhduthi = Tenfile;
                }
                db.HocSinhs.Add(hocSinh);
                db.SaveChanges();
                return RedirectToAction("Xemdanhsach");
            }

            ViewBag.malop = new SelectList(db.LopHocs, "malop", "tenlop", hocSinh.malop);
            return View(hocSinh);
        }
        public ActionResult ThongKe()
        {
            var danhsachs = db.LopHocs.Select(d => new ThongKe
            {
                malop= d.tenlop,
                sl= d.HocSinhs.Count()
            }).ToList();    
            return View(danhsachs);
        }

        // GET: Objects/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocSinh hocSinh = db.HocSinhs.Find(id);
            if (hocSinh == null)
            {
                return HttpNotFound();
            }
            ViewBag.malop = new SelectList(db.LopHocs, "malop", "tenlop", hocSinh.malop);
            return View(hocSinh);
        }


        // POST: Objects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sbd,hoten,anhduthi,malop,diemthi")] HocSinh hocSinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hocSinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.malop = new SelectList(db.LopHocs, "malop", "tenlop", hocSinh.malop);
            return View(hocSinh);
        }

        // GET: Objects/Delete/5
        public ActionResult XoaDulieu(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HocSinh hocSinh = db.HocSinhs.Find(id);
            if (hocSinh == null)
            {
                return HttpNotFound();
            }
            return View(hocSinh);
        }
        

        // POST: Objects/Delete/5
        [HttpPost, ActionName("XoaDulieu")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HocSinh hocSinh = db.HocSinhs.Find(id);
            db.HocSinhs.Remove(hocSinh);
            db.SaveChanges();
            return RedirectToAction("Xemdanhsach");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
