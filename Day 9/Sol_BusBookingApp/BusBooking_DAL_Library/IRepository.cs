using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking_DAL_Library
{
    public interface IRepository<K,T> where T : class
    {
        List<T> GetAll();
        T GetById(K id);
        T Add(T entity);
       T Delete(K id);
       
        T Update(T entity);
    }
}
