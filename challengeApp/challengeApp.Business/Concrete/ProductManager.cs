using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using challengeApp.Business.Abstract;
using challengeApp.DataAccess.Abstract;
using challengeApp.Entities;

namespace challengeApp.Business.Concrete
{    //Product Manager üzerinden yapılan işlemleri Databaseden getirir.
    public class ProductManager : IProductService
    {
        private IProductDal _pDal;
        public ProductManager(IProductDal pDal)
        {
            _pDal = pDal;
        }
        public void Create(Product entity)
        {
            _pDal.Create(entity);
        }

        public void Delete(Product entity)
        {
            _pDal.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _pDal.GetAll();
        }

        public Product GetById(int id)
        {
            return _pDal.GetById(id);
        }

        public List<Product> GetSearch(string search)
        {
            return _pDal.GetSearch(search);
        }

        public List<Product> GetSort(string sortOrder)
        {
            return _pDal.GetSort(sortOrder);
        }

        public void Update(Product entity)
        {
            _pDal.Update(entity);
        }
    }
}
