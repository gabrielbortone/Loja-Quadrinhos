using Loja_Quadrinhos.Models;
using System.Linq;

namespace Loja_Quadrinhos.Repositories.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        public IQueryable<Produto> GetByCategoria(Categoria categoria);
    }
}
