using System;
using System.Collections.Generic;
using System.Text;
using challengeApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace challengeApp.DataAccess.Concrete.EntityFrameworkCore
{
    public class ChallengeContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ChallengeDb;integrated security=true;");
        }
        public DbSet<Product> Products { get; set; }
    }
}
