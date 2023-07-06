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
            List<SelectListItem> degerler = (from i in db.TBLKULUPLERs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER o)
        {
            var klp=db.TBLKULUPLERs.Where(m=>m.KULUPID == o.TBLKULUPLER.KULUPID).FirstOrDefault();
            o.TBLKULUPLER = klp;
            db.TBLOGRENCILERs.Add(o);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}