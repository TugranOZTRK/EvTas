using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
	public interface IKasaService
	{
		void Add(Kasa kasa);
		void Delete(Kasa kasa);
		void Update(Kasa kasa);
		List<Kasa> GetList();
		Kasa GetById(int id);
	}
}
