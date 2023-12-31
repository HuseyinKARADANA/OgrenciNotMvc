﻿using System;
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

        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILERs.Find(id);
            db.TBLOGRENCILERs.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TBLOGRENCILERs.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKULUPLERs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("OgrenciGetir",ogrenci);
        }

        public ActionResult Guncelle(TBLOGRENCILER o)
        {
            var ogr = db.TBLOGRENCILERs.Find(o.OGRENCIID);
            ogr.OGRAD = o.OGRAD;
            ogr.OGRSOYAD = o.OGRSOYAD;
            ogr.OGRFOTO=o.OGRFOTO;
            ogr.OGRCINSIYET= o.OGRCINSIYET;
            ogr.OGRKULUP=o.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("Index","Ogrenci");
        }

    }
}