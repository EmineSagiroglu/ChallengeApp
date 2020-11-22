using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using challengeApp.DataAccess.Abstract;
using challengeApp.Entities;

namespace challengeApp.DataAccess.Concrete.EntityFrameworkCore
{   //Product'a özel ekstra metotları tanımlayacağımız alandır.
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, ChallengeContext>, IProductDal
    {
      

        public List<Product> GetSearch(string search)
        {
            using (var context =new ChallengeContext())
            {
                var products = context.Products.Where(i => i.İsDone && (i.ProductName.Contains(search) || i.ProductDefinition.Contains(search))).AsQueryable();
                return products.ToList();
            }

        }

        public List<Product> GetSort(string sortOrder)
        {
            throw new NotImplementedException();
        }
    }
}
