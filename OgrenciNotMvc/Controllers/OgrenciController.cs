using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMvc.Models.EntityFramework;
namespace OgrenciNotMvc.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        DbMvcOkulEntities db=new DbMvcOkulEntities();

        public ActionResult Index()
        {
            var ogrenciler=db.TBLOGRENCILERs.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER o)
        {
            db.TBLOGRENCILERs.Add(o);
            db.SaveChanges();
            return View();
        }
    }
}