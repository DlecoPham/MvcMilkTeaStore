using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMilkTeaStore.Models;

namespace MvcMilkTeaStore.Controllers
{
    public class ChudeController : Controller
    {
        QLBANTRASUAEntities database = new QLBANTRASUAEntities();
        // GET: Chude
        public ActionResult Index()
        {
            return View(database.CHUDEs.ToList());
        }
        [HttpPost]
        public ActionResult Index(string _name)
        {
            if (_name == null)
                return View(database.CHUDEs.ToList());
            else
                return View(database.CHUDEs.Where(s => s.TenChuDe.Contains(_name)).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CHUDE cate)
        {
            try
            {
                database.CHUDEs.Add(cate);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Error Create New");
            }
        }
        public ActionResult Details(int id)
        {
            return View(database.CHUDEs.Where(s => s.MaCD == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            return View(database.CHUDEs.Where(s => s.MaCD == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(int id, CHUDE cate)
        {
            database.Entry(cate).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View(database.CHUDEs.Where(s => s.MaCD == id).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(int id, CHUDE cate)
        {
            try
            {
                cate = database.CHUDEs.Where(s => s.MaCD == id).FirstOrDefault();
                database.CHUDEs.Remove(cate);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("This data is using in other table, Error Delete!");
            }
        }
    }
}