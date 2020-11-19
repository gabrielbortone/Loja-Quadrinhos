using Loja_Quadrinhos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Loja_Quadrinhos.Context
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 

        }
    }
}
