using Loja_Quadrinhos.Context;
using Loja_Quadrinhos.Models;
using Loja_Quadrinhos.Repositories.Interfaces;
using System.Linq;

namespace Loja_Quadrinhos.Repositories
{
    public class PedidoItemRepository : IPedidoItemRepository
    {
        private AppDbContext _context;
        public PedidoItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(PedidoItem entity)
        {
            _context.PedidoItens.Add(entity);
        }

        public void Delete(PedidoItem entity)
        {
            _context.PedidoItens.Remove(entity);
        }

        public IQueryable<PedidoItem> Get()
        {
            return _context.PedidoItens;
        }

        public PedidoItem GetById(int id)
        {
            return _context.PedidoItens.FirstOrDefault(pitem => pitem.PedidoItemId == id);
        }

        public void Update(PedidoItem entity)
        {
            _context.PedidoItens.Update(entity);
        }
    }
}
