using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcEntityTicariOtomasyonu.Models.Tablolar;

namespace MvcEntityTicariOtomasyonu.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        MyContext ctx = new MyContext();
        public ActionResult Index()
        {
            IkiliTablo cx = new IkiliTablo();//Sınıfımızdan nesne ürettik.

            cx.urunn = ctx.Uruns.ToList();//Nesneden İkili tablo sınıfındaki uruns listeledik.
            cx.UrunAyrıntıı = ctx.UrunAyrıntıs.ToList();//Nesneden İkili tablo sınıfındaki UeunAyrtıntıs listeledik.
            return View(cx);
        }
    }
}