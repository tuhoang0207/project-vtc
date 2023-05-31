using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<T > where T : class
    {
        bool Attach(T model);
        bool Update(T model);
        bool Delete(T model);
        IEnumerable<T> GetAll();
        T Find(int id);
    }
}
