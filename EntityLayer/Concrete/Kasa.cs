using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Kasa
    {
        public int Id { get; set; }
        public string Tur { get; set; }
        public DateTime Tarih { get; set; }
        public string Açıklama { get; set; }
        public int Miktar { get; set; }
        public bool Düzenli { get; set; }
    }
}
