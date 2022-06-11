using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEntityTicariOtomasyonu.Models.Tablolar;
using PagedList;
using PagedList.Mvc;

namespace MvcEntityTicariOtomasyonu.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        MyContext ctx = new MyContext();
        public ActionResult Index(string ara, int sayfano=1)
        {
            return View(ctx.Caris.Where(x=>x.CariAd.Contains(ara) || ara == null && x.Durum==true).ToList().ToPagedList(sayfano, 10));
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cari cars)
        {
            ctx.Caris.Add(cars);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var sil = ctx.Caris.Find(id);
            sil.Durum = false;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var getir = ctx.Caris.Find(id);
            return View("CariGetir",getir);
        }
        public ActionResult CariGuncelle(Cari cars)
        {
            var guncelle = ctx.Caris.Find(cars.CariId);
            guncelle.CariAd = cars.CariAd;
            guncelle.CariSoyad = cars.CariSoyad;
            guncelle.CariSifre = cars.CariSifre;
            guncelle.CariSehir = cars.CariSehir;
            guncelle.CariMail = cars.CariMail;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariBilgi(int id)
        {
            var listele = ctx.SatisHarekats.Where(x => x.CariId == id).ToList();
            return View(listele);

        }
    }
}