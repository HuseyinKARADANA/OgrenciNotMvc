using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
namespace OgrenciNotMvc.Controllers
{
    public class NotController : Controller
    {
        // GET: Not
        DbMvcOkulEntities db=new DbMvcOkulEntities();

        public ActionResult Index()
        {
            var notlar = db.TBLNOTLARs.ToList();
            return View(notlar);
        }
        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR n)
        {
            db.TBLNOTLARs.Add(n);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}