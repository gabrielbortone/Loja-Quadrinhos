using Loja_Quadrinhos.Models;
using System.Linq;

namespace Loja_Quadrinhos.Repositories.Interfaces
{
    public interface IPedidoItemRepository : IRepository<PedidoItem>
    {
        IQueryable<PedidoItem> GetPedidoItemByPedidoId(int pedidoId);
    }
}
