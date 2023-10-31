using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Is
	{
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; }
        public string YSehirId { get; set; }
        public Sehirler Sehirler { get; set; }
        public string YIlceId { get; set; }
        public Ilceler Ilceler{ get; set; }
        public string YMahalleId { get; set; }
        public Mahalle Mahalleler { get; set; }
        public string YuklemeAdres { get; set; }
        public string ISehirId{ get; set; }
        public string IIlceId{ get; set; }
        public string IMahalleId{ get; set; }
        public string IndirmeAdres{ get; set; }
        public bool Aktif { get; set; }
    }
}
