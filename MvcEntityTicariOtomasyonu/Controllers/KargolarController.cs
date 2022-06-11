using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEntityTicariOtomasyonu.Models.Tablolar;

namespace MvcEntityTicariOtomasyonu.Controllers
{
    public class KargolarController : Controller
    {
        // GET: Kargolar

        MyContext ctx = new MyContext();
        public ActionResult Index(string ara)
        {
            //var degerler = from x in ctx.KargoAyintis select x;
            //var listele = ctx.KargoAyintis.Where(x => x.KargoDurumu == true).ToList();
            //if (!string.IsNullOrEmpty(ara))
            //{
            //    degerler = degerler.Where(m => m.KargoMüsteri.Contains(ara));
            //}
            //return View(listele.ToList());
            var listele = ctx.KargoAyintis.Where(x => x.KargoKodu.Contains(ara) || ara == null).Where(y => y.KargoDurumu == true).ToList();
            return View(listele);
        }
        [HttpGet]
        public ActionResult KargoEkle()
        {
            Random kod = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G","H","I","J","K","L","M","N","O","P","R","S","T","U","V",
            "Y","Z","0","1","2","3","4","5","6","7","8","9"};
            int k1, k2, k3, k4, k5, k6, k7, k8, k9, k10;
            k1 = kod.Next(0, 33);
            k2 = kod.Next(0, 33);
            k3 = kod.Next(0, 33);
            k4 = kod.Next(0, 33);
            k5 = kod.Next(0, 33);
            k6 = kod.Next(0, 33);
            k7 = kod.Next(0, 33);
            k8 = kod.Next(0, 33);
            k9 = kod.Next(0, 33);
            k10 = kod.Next(0, 33);
            string dizikodu = karakterler[k1] + karakterler[2] + karakterler[k3] + karakterler[k4] + karakterler[k5] + karakterler[k6] +
            karakterler[k7] + karakterler[k8] + karakterler[k9] + karakterler[k10];
            ViewBag.takipkodu = dizikodu;
            return View();
        }

        [HttpPost]
        public ActionResult KargoEkle(KargoAyinti ka)
        {
            ctx.KargoAyintis.Add(ka);
            ka.KargoDurumu = true;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoSil(int id)
        {
            var bul = ctx.KargoAyintis.Find(id);
            bul.KargoDurumu = false;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoyuTakipEt(string id)
        {
            var deger = ctx.Kargoİzlemes.Where(x => x.TakipKodu == id).ToList();
            return View(deger);
        }
    }
}