using System.Collections.Generic;

namespace Loja_Quadrinhos.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
