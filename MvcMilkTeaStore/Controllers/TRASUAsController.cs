using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMilkTeaStore.Models;
using System.IO;

namespace MvcMilkTeaStore.Controllers
{
    public class TRASUAsController : Controller
    {
        private QLBANTRASUAEntities db = new QLBANTRASUAEntities();

        // GET: TRASUAs
        public ActionResult Index()
        {
            var tRASUAs = db.TRASUAs.Include(t => t.CHUDE);
            return View(tRASUAs.ToList());
        }

        // GET: TRASUAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRASUA tRASUA = db.TRASUAs.Find(id);
            if (tRASUA == null)
            {
                return HttpNotFound();
            }
            return View(tRASUA);
        }

        // GET: TRASUAs/Create
        public ActionResult Create()
        {
            TRASUA pro = new TRASUA();
            return View(pro);
        }

        // POST: TRASUAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(TRASUA pro)
        {
            try
            {
                if(pro.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent = Path.GetExtension(pro.UploadImage.FileName);
                    filename = filename + extent;
                    pro.Hinhminhhoa = "/Images/" + filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Images/"), filename));

                }
                db.TRASUAs.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } 

        // GET: TRASUAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRASUA tRASUA = db.TRASUAs.Find(id);
            if (tRASUA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenChuDe", tRASUA.MaCD);
            return View(tRASUA);
        }

        // POST: TRASUAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Matrasua,Tentrasua,Donvitinh,Dongia,Mota,Hinhminhhoa,MaCD,Ngaycapnhat,Soluongban,solanxem")] TRASUA tRASUA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRASUA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCD = new SelectList(db.CHUDEs, "MaCD", "TenChuDe", tRASUA.MaCD);
            return View(tRASUA);
        }

        // GET: TRASUAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRASUA tRASUA = db.TRASUAs.Find(id);
            if (tRASUA == null)
            {
                return HttpNotFound();
            }
            return View(tRASUA);
        }

        // POST: TRASUAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRASUA tRASUA = db.TRASUAs.Find(id);
            db.TRASUAs.Remove(tRASUA);
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
        public ActionResult SelectCate()
        {
            CHUDE se_cate = new CHUDE();
            se_cate.ListCate = db.CHUDEs.ToList<CHUDE>();
            return PartialView(se_cate);
        }
    }
}
