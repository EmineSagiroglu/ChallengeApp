using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using challengeApp.Entities;

namespace challengeApp.DataAccess.Abstract
{
    public interface IRepository<T>
    {
        //Id ile filtreleme işlemi
        T GetById(int id);
        //Id olmadan tek kayıt gönderme işlemi
        T GetOne(Expression<Func<T, bool>> filter);
        //Tüm kayıtları alır.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
       
    }
}
