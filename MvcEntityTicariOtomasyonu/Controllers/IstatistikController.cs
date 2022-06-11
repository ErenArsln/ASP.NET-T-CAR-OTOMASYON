using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEntityTicariOtomasyonu.Models.Tablolar;

namespace MvcEntityTicariOtomasyonu.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        MyContext ctx = new MyContext();
        public ActionResult Index()
        {
            var listele = ctx.Caris.Count().ToString();
            ViewBag.l1 = listele;

            var listele2 = ctx.Uruns.Count().ToString();
            ViewBag.l2 = listele2;

            var listele3 = ctx.Personels.Count().ToString();
            ViewBag.l3 = listele3;

            var listele4 = ctx.Kategoris.Count().ToString();
            ViewBag.l4 = listele4;

            var listele5 = ctx.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.l5 = listele5;

            var listele6 = (from x in ctx.Uruns select x.UrunMarka).Distinct().Count().ToString();
            ViewBag.l6 = listele6;

            var listele7 = ctx.Uruns.Count(x => x.Stok <= 100).ToString();
            ViewBag.l7 = listele7;

            var listele8 = (from x in ctx.Uruns orderby x.SatisFiyati descending select x.UrunAd).FirstOrDefault();
            ViewBag.l8 = listele8;

            var listele9 = (from x in ctx.Uruns orderby x.SatisFiyati ascending select x.UrunAd).FirstOrDefault();
            ViewBag.düsükfiyat = listele9;

            var listele10 = ctx.Uruns.GroupBy(x => x.UrunMarka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.marka = listele10;

            var listele11 = ctx.Uruns.Count(x => x.UrunAd == "Buzdolabı");
            ViewBag.buzdolabi = listele11;

            var listele12 = ctx.Uruns.Count(x => x.UrunMarka == "Laptop");
            ViewBag.laptop = listele12;

            var listele13 = ctx.SatisHarekats.Sum(x => x.ToplamTutar);
            ViewBag.toplamtutar = listele13;

            DateTime gün = DateTime.Today;
            var listele14 = ctx.SatisHarekats.Count(x => x.Tarih == gün);
            ViewBag.günsatis = listele14;

            var listele15 = ctx.Uruns.Where(a => a.UrunId == (ctx.SatisHarekats.GroupBy(b => b.UrunId).OrderByDescending(z => z.Count()).
            Select(c => c.Key).FirstOrDefault())).Select(e => e.UrunAd).FirstOrDefault();
            ViewBag.coksatan = listele15;

            var listele16 = ctx.Uruns.Count(x => x.Stok > 500);
            ViewBag.aktif = listele16;
            return View();

        }
        public ActionResult BasitTablolar()
        {
            var listele = from x in ctx.Caris
                          group x by x.CariSehir into a
                          select new GroupBy
                          {
                              Sehir = a.Key,
                              ToplamAdet = a.Count()
                          };
            return View(listele.ToList());
        }
        public PartialViewResult par1()
        {
            var listele2 = from x in ctx.Personels
                          group x by x.Departman.DepartmanAd into b
                          select new GroupBy2
                          {
                              DepartmaId = b.Key,
                              DepartmanAdet = b.Count()
                          };
                         
            return PartialView(listele2.ToList());
        }
        public PartialViewResult PartialCari()
        {
            var listele3 = ctx.Caris.ToList();
            return PartialView(listele3);
        }
        public PartialViewResult PartialUrun()
        {
            var listele4 = ctx.Uruns.ToList();
            return PartialView(listele4);
        }
        public PartialViewResult PartialPersonel()
        {
            var listele5 = ctx.Personels.ToList();
            return PartialView(listele5);
        }
   
    }
}