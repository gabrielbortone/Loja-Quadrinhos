using Loja_Quadrinhos.Context;
using Loja_Quadrinhos.Repositories.Interfaces;

namespace Loja_Quadrinhos.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private ProdutoRepository _produtoRepo;
        private CategoriaRepository _categoriaRepo;
        private PedidoRepository _pedidoRepo;
        private PedidoItemRepository _pedidoItemRepo;
        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepo = _produtoRepo ?? new ProdutoRepository(_context);
            }
        }

        public ICategoriaRepository CategoriaRepository 
        {
            get
            {
                return _categoriaRepo ?? new CategoriaRepository(_context);
            }
        }
        public IPedidoRepository PedidoRepository
        {
            get
            {
                return _pedidoRepo ?? new PedidoRepository(_context);
            }
        }

        public IPedidoItemRepository PedidoItemRepository
        {
            get
            {
                return _pedidoItemRepo ?? new PedidoItemRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
