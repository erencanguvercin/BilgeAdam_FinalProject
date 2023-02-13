using Project.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repository
{
    public interface IRepository<T> where T:BaseEntity 
    {
        IEnumerable<T> GetAll();
        //Create
        void Insert(T entity);
        //Delete
        void Remove(T entity);
        //Update
        void Update(T entity);
        //Get
        T Get(int id);
        string SaveChanges();
    }
}
