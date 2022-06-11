using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEntityTicariOtomasyonu.Models.Tablolar;
using PagedList;
using PagedList.Mvc;

namespace MvcEntityTicariOtomasyonu.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        MyContext ctx = new MyContext();
        public PersonelController()
        {
            List<SelectListItem> listele = (from x in ctx.Departmans.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.DepartmanAd,
                                                Value = x.DepartmanId.ToString()
                                            }
                                         ).ToList();
            ViewBag.sec = listele;
        }
        public ActionResult Index(string ara, int sayfano = 1)
        {
            return View(ctx.Personels.Where(x => x.PersonelAd.Contains(ara) ||
            ara == null && x.Durum == true).ToList().ToPagedList(sayfano, 6));
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel pers)
        {
            ctx.Personels.Add(pers);
            ctx.SaveChanges();
            return RedirectToAction("PersonelListe");
        }

        public ActionResult PersonelGetir(int id)
        {
            var getir = ctx.Personels.Find(id);
            ViewBag.ayrinti = id;
            return View("PersonelGetir", getir);
        }
        public ActionResult PersonelGuncelle(Personel perso)
        {
            var guncelle = ctx.Personels.Find(perso.PersonelId);
            guncelle.PersonelAd = perso.PersonelAd;
            guncelle.PersonelSoyad = perso.PersonelSoyad;
            guncelle.PersonelYas = perso.PersonelYas;
            guncelle.PersonelTelefon = perso.PersonelTelefon;
            guncelle.PersonelMail = perso.PersonelMail;
            guncelle.PersonelGörsel = perso.PersonelGörsel;
            guncelle.Durum = perso.Durum;
            guncelle.DepartmanId = perso.DepartmanId;
            ctx.SaveChanges();
            return RedirectToAction("PersonelListe");
        }
        public ActionResult PersonelListe(string ara, int sayfano = 1)
        {
           

            var listele = ctx.Personels.Where(X => X.Durum == true).ToList();
            return View(listele);
        }
        public ActionResult PersonelSil(int id)
        {
            var sil = ctx.Personels.Find(id);
            sil.Durum = false;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}