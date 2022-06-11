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
    public class KategoriController : Controller
    {
        // GET: Kategori

        MyContext ctx = new MyContext();
        public ActionResult Index(int sayfano=1)
        {
            var listele = ctx.Kategoris.Where(x => x.Durum == true).ToList().ToPagedList(sayfano,10);
            return View(listele);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori ktgr)
        {
            ctx.Kategoris.Add(ktgr);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var sil = ctx.Kategoris.Find(id);
            sil.Durum = false;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var getir = ctx.Kategoris.Find(id);
            return View("KategoriGetir", getir);
        }
        public ActionResult KategoriGuncelle(Kategori katgr)
        {
            var guncelle = ctx.Kategoris.Find(katgr.KategoriId);
            guncelle.KategoriAd = katgr.KategoriAd;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriAyrıntı(int id)
        {
            var ayrıntı = ctx.Uruns.Where(x => x.KategoriId == id).ToList();
            return View(ayrıntı);
        }
        public ActionResult SatisUrunIncele(int id)
        {
            var incele = ctx.SatisHarekats.Where(x => x.UrunId == id).ToList();
            return View(incele);
        }
    }
}