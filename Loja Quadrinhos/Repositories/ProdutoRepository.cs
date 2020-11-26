using Loja_Quadrinhos.Context;
using Loja_Quadrinhos.Models;
using Loja_Quadrinhos.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Loja_Quadrinhos.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private AppDbContext _context;
        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Produto entity)
        {
            _context.Produtos.Add(entity);
        }

        public void Delete(Produto entity)
        {
            _context.Produtos.Remove(entity);
        }

        public IEnumerable<Produto> Get()
        {
            return _context.Produtos.Include(p=>p.Categoria).OrderBy(p=>p.QuantidadeVendidos).ToList();
        }

        public IQueryable<Produto> GetByCategoria(Categoria categoria)
        {
            return _context.Produtos.Include(p => p.Categoria).Where(p => p.Categoria == categoria);
        }

        public Produto GetById(int id)
        {
            return _context.Produtos.Include(p => p.Categoria).FirstOrDefault(p => p.ProdutoId == id);
        }

        public void Update(Produto entity)
        {
            _context.Produtos.Update(entity);
        }
    }
}
