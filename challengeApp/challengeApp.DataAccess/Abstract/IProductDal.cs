using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using challengeApp.Entities;

namespace challengeApp.DataAccess.Abstract
{   //Bu Interfacede product tablosuna özel ilgili işlemler olucak.
    public interface IProductDal:IRepository<Product>
    {
        List<Product> GetSearch(string search);
        List<Product> GetSort(string sortOrder);

    }

}
