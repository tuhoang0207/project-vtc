﻿using DAL.Entities;
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

        public   Category GetProductByCategory(int id)
        {
           return  entities
                .Include(cate => cate.Products)
                .Where(cate =>cate.Cate_no == id).FirstOrDefault();
        }
    }
}
