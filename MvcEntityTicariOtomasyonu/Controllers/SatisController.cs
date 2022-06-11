using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEntityTicariOtomasyonu.Models.Tablolar;

namespace MvcEntityTicariOtomasyonu.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MyContext ctx = new MyContext();
        public ActionResult Index()
        {
            var listele = ctx.SatisHarekats.Where(x => x.Durum == true).ToList();
            return View(listele);
        }

        [HttpGet]
        public ActionResult SatisEkle()
        {
            List<SelectListItem> listele = (from x in ctx.Personels.ToList()
                                            select new SelectListItem
                                            {
                                                Text = (x.PersonelAd+" "+x.PersonelSoyad),
                                                Value = x.PersonelId.ToString()
                                            }).ToList();
            //******************************************************************
            List<SelectListItem> listele2 = (from x in ctx.Caris.ToList()
                                            select new SelectListItem
                                            {
                                                Text = (x.CariAd+" "+x.CariSoyad),
                                                Value = x.CariId.ToString()
                                            }).ToList();
            //*******************************************************************
            List<SelectListItem> listele3 = (from x in ctx.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunId.ToString()
                                            }).ToList();
            ViewBag.sec = listele;
            ViewBag.sec2 = listele2;
            ViewBag.sec3 = listele3;                                
            return View();
        }

        [HttpPost]
        public ActionResult SatisEkle(SatisHareket sk,Urun us)
        {

            sk.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            sk.Durum = true;
            ctx.SatisHarekats.Add(sk);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> listele = (from x in ctx.Personels.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.PersonelAd,
                                                Value = x.PersonelId.ToString()
                                            }).ToList();
            //******************************************************************
            List<SelectListItem> listele2 = (from x in ctx.Caris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = (x.CariAd + " " + x.CariSoyad),
                                                 Value = x.CariId.ToString()
                                             }).ToList();
            //*******************************************************************
            List<SelectListItem> listele3 = (from x in ctx.Uruns.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.UrunAd,
                                                 Value = x.UrunId.ToString()
                                             }).ToList();
            ViewBag.sec = listele;
            ViewBag.sec2 = listele2;
            ViewBag.sec3 = listele3;
            var getir = ctx.SatisHarekats.Find(id);
            return View("SatisGetir", getir);
        }
        public ActionResult SatisGuncelle(SatisHareket satis)
        {
            var guncelle = ctx.SatisHarekats.Find(satis.SatisId);
            guncelle.PersonelId = satis.PersonelId;
            guncelle.CariId = satis.CariId;
            guncelle.UrunId = satis.UrunId;
            guncelle.Adet = satis.Adet;
            guncelle.Fiyat = satis.Fiyat;
            guncelle.ToplamTutar = satis.ToplamTutar;
            guncelle.Tarih = satis.Tarih;
            guncelle.Durum = satis.Durum;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var listele = ctx.SatisHarekats.Where(x => x.SatisId == id).ToList();
            return View(listele);
        }
    }
}