using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcEntityTicariOtomasyonu.Models.Tablolar
{
    public class IkiliTablo
    {
        public IEnumerable<Urun> urunn { get; set; }
        public IEnumerable<UrunAyrıntı> UrunAyrıntıı { get; set; }

    }
}