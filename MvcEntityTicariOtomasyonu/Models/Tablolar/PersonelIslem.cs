using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class PersonelIslem
    {
        public IEnumerable<Personel> personels { get; set; }
        public IEnumerable<Cari> caris { get; set; }
    }
}