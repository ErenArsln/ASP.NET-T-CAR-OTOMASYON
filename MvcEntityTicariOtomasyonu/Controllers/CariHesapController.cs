using MvcEntityTicariOtomasyonu.Models.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEntityTicariOtomasyonu.Controllers
{
    public class CariHesapController : Controller
    {
        // GET: CariHesap
        MyContext ctx = new MyContext();

        //[Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var giris = ctx.Caris.FirstOrDefault(x => x.CariMail == mail);
            return View(giris);
        }
        public ActionResult Siparis()
        {
            var bilgiler = (string)Session["CariMail"];
            var mail = ctx.Caris.Where(x => x.CariMail == bilgiler).Select(x => x.CariId).FirstOrDefault();
            var getir = ctx.SatisHarekats.Where(x => x.CariId == mail).ToList();
            return View(getir);

        }
        public ActionResult GelenMesajlar()
        {
            var bilgiler = (string)Session["CariMail"];
            var mesajlar = ctx.cariMesajs.Where(x=>x.MesajAlan==bilgiler).OrderBy(x=>x.MesajId).ToList();
            var gelenmesaj = ctx.cariMesajs.Count(x=>x.MesajAlan == bilgiler).ToString();
            var gidenmesaj = ctx.cariMesajs.Count(x => x.MesajGonderen == bilgiler).ToString();
            ViewBag.GelenMesajToplami = gelenmesaj;
            ViewBag.GidenMesajToplami = gidenmesaj;
            return View(mesajlar);
        }
        public ActionResult GidenMesajlar()
        {
            var bilgiler = (string)Session["CariMail"];
            var mesajlar = ctx.cariMesajs.Where(x => x.MesajGonderen == bilgiler).OrderByDescending(x=>x.MesajId).ToList();
            var gidenmesaj = ctx.cariMesajs.Count(x => x.MesajGonderen == bilgiler).ToString();
            var gelenmesaj = ctx.cariMesajs.Count(x => x.MesajAlan == bilgiler).ToString();
            ViewBag.GidenMesajToplami = gidenmesaj;
            ViewBag.GelenMesajToplami = gelenmesaj;
            return View(mesajlar);
        }
        public ActionResult MesajDetay( int id)
        {
            var degerler = ctx.cariMesajs.Where(x => x.MesajId == id).ToList();
            var bilgiler = (string)Session["CariMail"];
            var gelenmesaj = ctx.cariMesajs.Count(x => x.MesajAlan == bilgiler).ToString();
            var gidenmesaj = ctx.cariMesajs.Count(x => x.MesajGonderen == bilgiler).ToString();
            ViewBag.GelenMesajToplami = gelenmesaj;
            ViewBag.GidenMesajToplami = gidenmesaj;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var bilgiler = (string)Session["CariMail"];
            var gelenmesaj = ctx.cariMesajs.Count(x => x.MesajAlan == bilgiler).ToString();
            var gidenmesaj = ctx.cariMesajs.Count(x => x.MesajGonderen == bilgiler).ToString();
            ViewBag.GelenMesajToplami = gelenmesaj;
            ViewBag.GidenMesajToplami = gidenmesaj;
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(CariMesaj m)
        {
            var bilgiler = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.MesajGonderen = bilgiler;
            ctx.cariMesajs.Add(m);
            ctx.SaveChanges();
            return View();
        }
        public ActionResult KargoTakip(string ara)
        {
            var kargo = from x in ctx.KargoAyintis select x;
            kargo = kargo.Where(y => y.KargoKodu.Contains(ara));
            return View(kargo.ToList());
            //var bilgiler = (string)Session["CariMail"];
            //var mesajlar = ctx.KargoAyintis.Where(x => x.KargoKodu == bilgiler).ToList();
            //return View(mesajlar);

        }
        public ActionResult CariKargoTakip(int id)
        {
            var kargolistele = ctx.Kargoİzlemes.Where(x => x.KargoIzlemeId == id).ToList();
            return View(kargolistele);
        }
    }
}