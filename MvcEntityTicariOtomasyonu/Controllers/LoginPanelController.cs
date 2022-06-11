using MvcEntityTicariOtomasyonu.Models.Tablolar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEntityTicariOtomasyonu.Controllers
{
    //AllowAnonymous]
    public class LoginPanelController : Controller
    {

        MyContext ctx = new MyContext();
        // GET: LoginPanel
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult KayıtPartial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult KayıtPartial(Cari p)
        {
            var ekle = ctx.Caris.Add(p);
            ekle.Durum = true;
            ctx.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CariLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariLogin(Cari c)
        {
            var bilgiler = ctx.Caris.FirstOrDefault(x => x.CariMail == c.CariMail && x.CariSifre == c.CariSifre);
            if (bilgiler != null)
            {
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariHesap");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var bilgiler = ctx.Admins.FirstOrDefault(x => x.KullaniciAdi == a.KullaniciAdi && x.Sifre == a.Sifre);
            if (bilgiler != null)
            {
                Session["KullaniciAdi"] = bilgiler.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return View();
            }
        }
    }
}