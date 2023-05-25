using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CoffeeShopDbContext context) : base(context)
        {
        }

        public async Task<Category?> GetProductByCategory(int id)
        {
           return  await entities
                .Include(cate => cate.Products)
                .Where(cate =>cate.Cate_no == id).FirstOrDefaultAsync();
        }
    }
}
