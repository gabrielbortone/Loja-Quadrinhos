using Loja_Quadrinhos.Context;
using Loja_Quadrinhos.Models;
using Loja_Quadrinhos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public IEnumerable<Pedido> Get()
        {
            return _context.Pedidos.Include(pedido => pedido.PedidoItens).ToList();
        }

        public Pedido GetById(int id)
        {
            return _context.Pedidos.Include(pedido => pedido.PedidoItens).FirstOrDefault(pedido=> pedido.PedidoId == id);
        }

        public IQueryable<Pedido> GetPedidosByUser(Usuario usuario)
        {
            return _context.Pedidos.Include(pedido => pedido.PedidoItens).Where(pedido=> pedido.Usuario == usuario);
        }

        public void Update(Pedido entity)
        {
            _context.Pedidos.Update(entity);
        }
    }
}
