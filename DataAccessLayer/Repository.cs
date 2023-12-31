﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
	public class Repository<T> : IGenericDal<T> where T : class
	{
		Context c = new Context();
		DbSet<T> _object;
		public Repository()
		{
			_object = c.Set<T>();
		}
		public int Delete(T p)
		{
			_object.Remove(p);
			return c.SaveChanges();
		}

		public T GetById(int id)
		{
			return _object.Find(id);
		}

		public int Insert(T p)
		{
			_object.Add(p);
			return c.SaveChanges();
		}

		public List<T> GetListAll()
		{
			return _object.ToList();
		}

		public List<T> List(Expression<Func<T, bool>> filter)
		{
			return _object.Where(filter).ToList();
		}

		public int Update(T p)
		{
			return c.SaveChanges();
		}
	}
}
