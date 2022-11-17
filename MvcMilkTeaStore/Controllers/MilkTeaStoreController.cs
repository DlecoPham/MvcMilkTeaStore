using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMilkTeaStore.Models;

namespace MvcMilkTeaStore.Controllers
{
    public class MilkTeaStoreController : Controller
    {
        // GET: MilkTeaStore
        QLBANTRASUAEntities database = new QLBANTRASUAEntities();
        public ActionResult Index()
        {
            return View(database.TRASUAs.ToList());
        }
       
        public ActionResult LayChuDe()
        {
            var dsChuDe = database.CHUDEs.ToList();
            return PartialView(dsChuDe);
        }
        public ActionResult SPTheoChuDe(int id)
        {
            //Lấy các sách theo mã chủ đề được chọn
            var dsTraSuaTheoChuDe = database.TRASUAs.Where(trasua => trasua.MaCD ==id).ToList();
            //Trả về View để render các sách trên (tái sử dụng View Index ở trên, truyền vào danh sách)
            return View("Index", dsTraSuaTheoChuDe);
        }
        public ActionResult Details(int id)
        {
            //Lấy sách có mã tương ứng
            var trasua = database.TRASUAs.FirstOrDefault(s => s.Matrasua == id);
            return View(trasua);
        }
    }
}