using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(CoffeeShopDbContext context) : base(context)
        {
        }

        public async Task<int> BestSellingProduct()
        {
            return await context.Database.ExecuteSqlAsync($"Call USP_BestsellingProduct();");
        }

      
    }
}
