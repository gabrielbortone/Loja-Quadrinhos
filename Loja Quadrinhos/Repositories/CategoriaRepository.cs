using Loja_Quadrinhos.Context;
using Loja_Quadrinhos.Models;
using Loja_Quadrinhos.Repositories.Interfaces;
using System.Linq;

namespace Loja_Quadrinhos.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Categoria entity)
        {
            _context.Categorias.Add(entity);
        }

        public void Delete(Categoria entity)
        {
            _context.Categorias.Remove(entity);
        }

        public IQueryable<Categoria> Get()
        {
            return _context.Categorias;
        }

        public Categoria GetById(int id)
        {
            return _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
        }

        public void Update(Categoria entity)
        {
            _context.Categorias.Update(entity);
        }
    }
}
