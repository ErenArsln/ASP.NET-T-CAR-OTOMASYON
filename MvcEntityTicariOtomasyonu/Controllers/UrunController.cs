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
    public class UrunController : Controller
    {
        // GET: Urun

        MyContext ctx = new MyContext();

        public ActionResult Index(string ara, int sayfano = 1)
        {
            return View(ctx.Uruns.Where(x => x.UrunAd.Contains(ara) || ara == null).ToList().ToPagedList(sayfano, 10));

        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> sec = (from x in ctx.Kategoris.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.KategoriAd,
                                            Value = x.KategoriId.ToString()
                                        }
                                      ).ToList();
            ViewBag.dgr = sec;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun urn)
        {
            ctx.Uruns.Add(urn);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var sil = ctx.Uruns.Find(id);
            sil.Durum = false;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> sec = (from x in ctx.Kategoris.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.KategoriAd,
                                            Value = x.KategoriId.ToString()
                                        }
                                         ).ToList();
            ViewBag.dgr = sec;
            var getir = ctx.Uruns.Find(id);
            return View("UrunGetir", getir);
        }
        public ActionResult UrunGuncelle(Urun urnn)
        {
            var guncelle = ctx.Uruns.Find(urnn.UrunId);
            guncelle.UrunAd = urnn.UrunAd;
            guncelle.UrunMarka = urnn.UrunMarka;
            guncelle.Stok = urnn.Stok;
            guncelle.AlisFiyati = urnn.AlisFiyati;
            guncelle.SatisFiyati = urnn.SatisFiyati;
            guncelle.UrunGorsel = urnn.UrunGorsel;
            guncelle.Durum = urnn.Durum;
            guncelle.KategoriId = urnn.KategoriId;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var listele = ctx.Uruns.ToList();
            return View(listele);
        }

        [HttpGet]
        public ActionResult UrunSatis(int id)
        {
            List<SelectListItem> ekle = (from x in ctx.Personels.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.PersonelAd,
                                             Value = x.PersonelId.ToString()
                                         }).ToList();

            List<SelectListItem> ekle2 = (from x in ctx.Caris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.CariAd,
                                              Value = x.CariId.ToString()
                                          }).ToList();
            ViewBag.carisec = ekle2;
            ViewBag.personelsec = ekle;
            var id_bul = ctx.Uruns.Find(id);
            ViewBag.urunid = id_bul.UrunAd;
            ViewBag.fiyatid = id_bul.SatisFiyati;
            return View();
        }

        [HttpPost]
        public ActionResult UrunSatis(SatisHareket satis)
        {
            return View();
        }
    }
}