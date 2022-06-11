using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEntityTicariOtomasyonu.Models.Tablolar;

namespace MvcEntityTicariOtomasyonu.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman

        MyContext ctx = new MyContext();
        public ActionResult Index()
        {
            var listele = ctx.Departmans.Where(x => x.Durum == true).ToList();
            return View(listele);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman dprt)
        {
            var ekle = ctx.Departmans.Add(dprt);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var sil = ctx.Departmans.Find(id);
            sil.Durum = false;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var getir = ctx.Departmans.Find(id);
            return View("DepartmanGetir",getir);
        }
        public ActionResult DepartmanGuncelle(Departman deprat)
        {
            var guncelle = ctx.Departmans.Find(deprat.DepartmanId);
            guncelle.DepartmanAd = deprat.DepartmanAd;
            guncelle.Durum = deprat.Durum;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanAyrıntı(int id)
        {
            var listele = ctx.Personels.Where(x => x.DepartmanId == id).ToList();
            return View(listele);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var listele = ctx.SatisHarekats.Where(x => x.PersonelId == id).ToList();
            return View(listele);
        }
    }
}