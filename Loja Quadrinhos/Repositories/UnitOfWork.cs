using Loja_Quadrinhos.Context;
using Loja_Quadrinhos.Repositories.Interfaces;

namespace Loja_Quadrinhos.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        public IProdutoRepository ProdutoRepository { get; }
        public ICategoriaRepository CategoriaRepository { get; }
        public IPedidoRepository PedidoRepository { get; }
        public IPedidoItemRepository PedidoItemRepository { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            ProdutoRepository = new ProdutoRepository(_context);
            CategoriaRepository = new CategoriaRepository(_context);
            PedidoRepository = new PedidoRepository(_context);
            PedidoItemRepository = new PedidoItemRepository(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
