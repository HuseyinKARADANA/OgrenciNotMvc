using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
namespace OgrenciNotMvc.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbMvcOkulEntities db=new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var kulupler=db.TBLKULUPLERs.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER k)
        {
            db.TBLKULUPLERs.Add(k);
            db.SaveChanges();
            return View();
        }

        public ActionResult Sil(int id)
        {
            var kulup=db.TBLKULUPLERs.Find(id);
            db.TBLKULUPLERs.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KulupGetir(int id)
        {
            var kulup = db.TBLKULUPLERs.Find(id);

            return View("KulupGetir",kulup);
        }

    }
}