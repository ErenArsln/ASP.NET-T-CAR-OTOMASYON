using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEntityTicariOtomasyonu.Models.Tablolar;

namespace MvcEntityTicariOtomasyonu.Controllers
{
    public class YapilacaklarController : Controller
    {
        MyContext ctx = new MyContext();
        // GET: Yapilacaklar
        public ActionResult Index()
        {
            var kt = ctx.Kategoris.Count().ToString();
            ViewBag.KategoriToplam = kt;

            var ut = ctx.Uruns.Count().ToString();
            ViewBag.UrunToplam = ut;

            var pt = ctx.Personels.Count().ToString();
            ViewBag.PersonelToplam = pt;
            
            var us = ctx.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.UrunStokSum = us;

            var listele = ctx.yapilacaklars.ToList();
            return View(listele);
        }
    }
}