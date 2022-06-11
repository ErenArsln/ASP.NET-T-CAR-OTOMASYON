using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEntityTicariOtomasyonu.Models.Tablolar;

namespace MvcEntityTicariOtomasyonu.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        MyContext ctx = new MyContext();
        public ActionResult Index()
        {
            Fatura_FaturaKalem ff = new Fatura_FaturaKalem();
            ff.faturakalemm = ctx.FaturaKalems.ToList();
            ff.faturaa = ctx.Faturas.ToList();
            return View(ff);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Fatura ftr)
        {
            ctx.Faturas.Add(ftr);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var getir = ctx.Faturas.Find(id);
            return View("FaturaGetir", getir);
        }
        public ActionResult FaturaGuncelle(Fatura ftr)
        {
            var guncelle = ctx.Faturas.Find(ftr.FaturaId);
            guncelle.FaturaSeriNo = ftr.FaturaSeriNo;
            guncelle.FaturaSıraNo = ftr.FaturaSıraNo;
            guncelle.VergiDairesi = ftr.VergiDairesi;
            guncelle.TeslimAlan = ftr.TeslimAlan;
            guncelle.TeslimEden = ftr.TeslimEden;
            guncelle.Saat = ftr.Saat;
            guncelle.Tarih = ftr.Tarih;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var listele = ctx.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            return View(listele);
        }

        [HttpGet]
        public ActionResult YeniKalemGiris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalemGiris(FaturaKalem fklm)
        {
            ctx.FaturaKalems.Add(fklm);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}