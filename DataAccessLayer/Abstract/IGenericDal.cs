using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IGenericDal<T> where T : class
	{
		T GetById(int id);
		int Insert(T p);
		int Update(T p);
		int Delete(T p);
		List<T> GetListAll();
		List<T> List(Expression<Func<T, bool>> filter);
	}
}
