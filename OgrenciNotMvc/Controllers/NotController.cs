using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
using OgrenciNotMvc.Models;
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

        public ActionResult NotGetir(int id)
        {
            var notlar=db.TBLNOTLARs.Find(id);
            return View("NotGetir",notlar);
        }
        [HttpPost]
        public ActionResult NotGetir(Class1 model, TBLNOTLAR n,int sinav1=0,int sinav2=0,int sinav3=0,int proje=0)
        {
            if (model.islem=="HESAPLA")
            {
                int ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
                ViewBag.ort = ortalama;
            }
            if (model.islem == "NOTGUNCELLE")
            {
                var snv = db.TBLNOTLARs.Find(n.NOTID);
                snv.SINAV1=n.SINAV1;
                snv.SINAV2=n.SINAV2;
                snv.SINAV3=n.SINAV3;
                snv.PROJE = n.PROJE;
                snv.ORTALAMA = n.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index","Not");
            }
            return View();
        }
    }
}