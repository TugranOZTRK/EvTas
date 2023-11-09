using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Araclar
	{
        [Key]
        public int AracId { get; set; }
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public bool Aktif { get; set; }
    }
}
