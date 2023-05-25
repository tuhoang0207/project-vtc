using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<T > where T : class
    {
        Task<bool> Attach(T model);
        Task<bool> Update(T model);
        Task<bool> Delete(T model);
        Task<IEnumerable<T>> GetAll();
        Task<T> Find(int id);
    }
}
