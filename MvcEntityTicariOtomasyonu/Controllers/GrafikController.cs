using MvcEntityTicariOtomasyonu.Models.Tablolar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcEntityTicariOtomasyonu.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Grafik()
        {
            var grafikler = new Chart(600, 650);// genişlik ve boyunu belirledik.
            grafikler.AddTitle("KATEGORİ-ÜRÜN").AddLegend("Stok Sayısı").AddSeries("İstatistikler", xValue: new[]// Başlıkları ekledik.
            {"Bilgisayar Parçası","Beyaz Eşya","Telefon" }, yValues: new[] { 732, 141, 674 }).Write();//X ve Y eksenindeki yazıları belirledik.
            return File /*Fİle doya türü demek*/ (grafikler.ToWebImage().GetBytes(), "Index.jpg");//Web resmini byte olarak aldık ve yazdırdık.
        }
        MyContext grfk = new MyContext();// yeni nesne tnaımladık
        public ActionResult GrafikIndex()
        {
            ArrayList xvalue = new ArrayList();// X ekseni için yeni arraylist yaptık.
            ArrayList yvalue = new ArrayList();//Y ekseni için yeni arraylist yaptık.
            var degerler = grfk.Uruns.ToList();//Nereyi listeliceksek onu seçtik yani ürünleri seçtik.
            degerler.ToList().ForEach(x => xvalue.Add(x.UrunAd));//Forecah döngüsüyle neyin listeleneceğini x ekseninde yazdırdık.
            degerler.ToList().ForEach(y => yvalue.Add(y.Stok));//Forecah döngüsüyle neyin listeleneceğini x ekseninde yazdırdık.
            var boyut = new Chart(width: 1600, height: 1600)//Yeni değişken belirleyip boyunu verdik.
                .AddTitle("Ürün Stokları")
                .AddLegend("StokSaysı")
                .AddSeries( xValue: xvalue, yValues: yvalue);
            return File(boyut.ToWebImage().GetBytes(), "Index.jpg");
        }
        public ActionResult GrafikChartIndex()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult()//görselleştirme
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<Grafik1> UrunListesi()
        {
            List<Grafik1> grfk = new List<Grafik1>();
            grfk.Add(new Grafik1()
            {
                UrunAd="Telefon",
                Stok=541
            });
            grfk.Add(new Grafik1()
            {
                UrunAd = "Beyaz Eşya",
                Stok = 185
            });
            grfk.Add(new Grafik1()
            {
                UrunAd = "Bilgisayar Parçası",
                Stok = 741
            });
            grfk.Add(new Grafik1()
            {
                UrunAd = "Mobilya",
                Stok = 241
            });
            return grfk;
        }
        public ActionResult GrafikChart2()
        {
            return View();
        }
        public ActionResult VisualizeUrunsResult()
        {
            return Json(UrunListeleri(), JsonRequestBehavior.AllowGet);

        }
        public List<Grafik2> UrunListeleri()
        {
            List<Grafik2> grfk2 = new List<Grafik2>();
            using (var MContext= new MyContext())
            {
                grfk2 = MContext.Uruns.Select(x => new Grafik2
                {
                    UrunAdı = x.UrunAd,
                    UrunStok = x.Stok
                }).ToList();
            }
            return grfk2;

        }
    }
}