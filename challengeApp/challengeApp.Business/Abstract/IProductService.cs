using System;
using System.Collections.Generic;
using System.Text;
using challengeApp.Entities;

namespace challengeApp.Business.Abstract
{
    //Bu Interfacede product tablosu ile ilgili işlemler olucak.
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetSearch(string search);
        List<Product> GetSort(string sortOrder);
        Product GetById(int id);
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);

    }
}
