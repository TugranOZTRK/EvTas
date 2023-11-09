using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EfRepository
{
	public class EfAracRepository : Repository<Araclar>, IAracDal
	{
		public Araclar FindByWithPlate(string plaka)
		{
			using (var gu = new Context())
			{
				return gu.Araclar.Where(x=>x.Plaka == plaka).ToList().FirstOrDefault();
			}
		}
	}
}
