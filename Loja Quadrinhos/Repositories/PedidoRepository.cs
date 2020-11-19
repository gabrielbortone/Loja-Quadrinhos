using Loja_Quadrinhos.Context;
using Loja_Quadrinhos.Models;
using Loja_Quadrinhos.Repositories.Interfaces;
using System.Linq;

namespace Loja_Quadrinhos.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private AppDbContext _context;
        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Pedido entity)
        {
            _context.Pedidos.Add(entity);
        }

        public void Delete(Pedido entity)
        {
            _context.Pedidos.Remove(entity);
        }

        public IQueryable<Pedido> Get()
        {
            return _context.Pedidos;
        }

        public Pedido GetById(int id)
        {
            return _context.Pedidos.FirstOrDefault(pedido=> pedido.PedidoId == id);
        }

        public void Update(Pedido entity)
        {
            _context.Pedidos.Update(entity);
        }
    }
}
