using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using challengeApp.DataAccess.Abstract;
using challengeApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace challengeApp.DataAccess.Concrete.EntityFrameworkCore
{   //Ortak olan metotların kullanıldığı alandır.Böylelikle kod tekrarına engel olundu.
    //Üzerinde çalışabileceği Generic tip ve DbContext tanımlamaları yapıldı.
    public class EfCoreGenericRepository<T, TContext> : IRepository<T>
        where T : class
        where TContext : DbContext, new()
    {
        public void Create(T entity)
        {
            using (var context=new TContext())
            {
                context.Set<T>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new TContext())
            {
                context.Set<T>().Remove(entity);
                context.SaveChanges();
            }
        }

        public virtual List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                         ? context.Set<T>().ToList()
                         : context.Set<T>().Where(filter).ToList();
            }
        }

        public T GetById(int id)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Find(id); //Id'ye göre sorgulama yapar.
            }
        }

        public T GetOne(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<T>().Where(filter).SingleOrDefault(); //Bulduğu ilk değeri alsın ,bulamazsa default dönsün.
            }
        }

     

        public void Update(T entity)
        {
            using (var context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
