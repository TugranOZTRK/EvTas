using BusinessLayer.Services;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace Business.Manager
{
	public class AraclarManager : IAraclarService
	{
		IAracDal _aracDal;
		public AraclarManager(IAracDal aracDal)
		{
			_aracDal = aracDal;
		}
		public void Add(Araclar araclar)
		{
			_aracDal.Insert(araclar);
		}

		public void Delete(Araclar araclar)
		{
			_aracDal.Delete(araclar);
		}

		public Araclar FindByWithPlate(string plaka)
		{
			return _aracDal.GetListAll().FirstOrDefault(c => c.Plaka == plaka);
		}

		public Araclar GetById(int id)
		{
			return _aracDal.GetById(id);
		}

		public List<Araclar> GetList()
		{
			return _aracDal.GetListAll();
		}

		public void Update(Araclar araclar)
		{
			_aracDal.Update(araclar);
		}
	}
}
