using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMilkTeaStore.Models;
using PagedList;
using PagedList.Mvc;
namespace MvcMilkTeaStore.Controllers
{
    public class MilkTeaStoreController : Controller
    {
        // GET: MilkTeaStore
        QLBANTRASUAEntities database = new QLBANTRASUAEntities();
        public ActionResult Index(string _name,int? page)
        {
            int pageSize = 8;
            int pageNum = (page ?? 1);
            if (_name == null)
                return View(database.TRASUAs.OrderByDescending(x=>x.Tentrasua).ToPagedList(pageNum,pageSize));
            else
                return View(database.TRASUAs.OrderByDescending(x=>x.Tentrasua).Where(s => s.Tentrasua.Contains(_name)).ToPagedList(pageNum,12));
        }
       
        public ActionResult LayChuDe()
        {
            var dsChuDe = database.CHUDEs.ToList();
            return PartialView(dsChuDe);
        }
        public ActionResult SPTheoChuDe(int id, int? page)
        {
            
            int pageNum = (page ?? 1);
            //Lấy trà sữa theo mã chủ đề được chọn
            var dsTraSuaTheoChuDe = database.TRASUAs.OrderByDescending(x=>x.Tentrasua).Where(trasua => trasua.MaCD == id).ToPagedList(pageNum, 16);
            //Trả về View để render sp trên (tái sử dụng View Index ở trên, truyền vào danh sách)
            return View("Index", dsTraSuaTheoChuDe);
        }
        public ActionResult Details(int id)
        {
            //Lấy trà sữa có mã tương ứng
            var trasua = database.TRASUAs.FirstOrDefault(s => s.Matrasua == id);
            return View(trasua);
        }
        public ActionResult TimKiem(string sTuKhoa)
        {
            var lstSP = database.TRASUAs.Where(n => n.Tentrasua.Contains(sTuKhoa));
            return View(lstSP.OrderBy(n => n.Tentrasua));
        }
    }
}