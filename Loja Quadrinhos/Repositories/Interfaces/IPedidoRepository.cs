using Loja_Quadrinhos.Models;
using System.Linq;

namespace Loja_Quadrinhos.Repositories.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        public IQueryable<Pedido> GetPedidosByUser(Usuario usuario);
    }
}
