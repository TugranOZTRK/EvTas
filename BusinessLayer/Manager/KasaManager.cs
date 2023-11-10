using BusinessLayer.Services;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace Business.Manager
{
	public class KasaManager : IKasaService
	{
		IKasaDal _kasaDal;
		public KasaManager(IKasaDal kasaDal)
		{
			_kasaDal = kasaDal;
		}
		public void Add(Kasa kasalar)
		{
			_kasaDal.Insert(kasalar);
		}

		public void Delete(Kasa kasalar)
		{
			_kasaDal.Delete(kasalar);
		}

		public Kasa GetById(int id)
		{
			return _kasaDal.GetById(id);
		}

		public List<Kasa> GetList()
		{
			return _kasaDal.GetListAll();
		}

		public void Update(Kasa kasalar)
		{
			_kasaDal.Update(kasalar);
		}
	}
}
