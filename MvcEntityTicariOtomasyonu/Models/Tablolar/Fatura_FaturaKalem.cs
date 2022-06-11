using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class Fatura_FaturaKalem
    {
        public IEnumerable<Fatura> faturaa { get; set; }
        public IEnumerable<FaturaKalem> faturakalemm { get; set; }
    }
}