using System;
using System.Linq;
using System.Linq.Expressions;

namespace Loja_Quadrinhos.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
