using Loja_Quadrinhos.Context;
using Loja_Quadrinhos.Models;
using Loja_Quadrinhos.Repositories.Interfaces;
using System.Collections.Generic;
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

        public IEnumerable<PedidoItem> Get()
        {
            return _context.PedidoItens.ToList();
        }

        public PedidoItem GetById(int id)
        {
            return _context.PedidoItens.FirstOrDefault(pitem => pitem.PedidoItemId == id);
        }

        public IQueryable<PedidoItem> GetPedidoItemByPedidoId(int pedidoId)
        {
            return _context.PedidoItens.Where(pitem => pitem.PedidoId == pedidoId);
        }

        public void Update(PedidoItem entity)
        {
            _context.PedidoItens.Update(entity);
        }
    }
}
