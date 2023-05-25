using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoryService :IService<Category>
    {
        Task<Category> GetProductByCategory(int categoryId);
    }
}
