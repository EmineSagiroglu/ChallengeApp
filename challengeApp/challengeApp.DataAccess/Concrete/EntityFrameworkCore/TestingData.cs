using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using challengeApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace challengeApp.DataAccess.Concrete.EntityFrameworkCore
{
    public static class TestingData
    {
        public static void Seed()
        {
            var context = new ChallengeContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                }
                context.SaveChanges();
            }
        }
        private static Product[] Products =
        {
            new Product(){ProductName="Sweatshirt",ProductPrice=78,ProductImage="Product1.jpg",ProductDefinition="Yakası Büzgü Detaylı Aktif Spor Sweatshirt",İsDone=true},
            new Product(){ProductName="Elbise",ProductPrice=98,ProductImage="Product2.jpg",ProductDefinition="Deri Görünümlü Elbise",İsDone=true},
            new Product(){ProductName="Tunik",ProductPrice=59,ProductImage="Product3.jpg",ProductDefinition="Slogan Baskılı Pamuklu Tunik",İsDone=true},
            new Product(){ProductName="Bot",ProductPrice=78,ProductImage="Product4.jpg",ProductDefinition="Kadın Bilek Boy Bot",İsDone=true},
            new Product(){ProductName="Çanta",ProductPrice=88,ProductImage="Product5.jpg",ProductDefinition="Kürklü Çapraz Çanta",İsDone=true},
            new Product(){ProductName="Sweatshirt",ProductPrice=119,ProductImage="Product6.jpg",ProductDefinition="Batik Desenli Sweatshirt",İsDone=true},
        };
    }
    
}
