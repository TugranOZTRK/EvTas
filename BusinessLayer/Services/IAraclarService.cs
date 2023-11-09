using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
	public interface IAraclarService
	{
		void Add(Araclar araclar);
		void Delete(Araclar araclar);
		void Update(Araclar araclar);
		List<Araclar> GetList();
		Araclar GetById(int id);
		Araclar FindByWithPlate(string plaka);
	}
}
