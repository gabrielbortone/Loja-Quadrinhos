using Loja_Quadrinhos.Context;
using Loja_Quadrinhos.Models;
using Loja_Quadrinhos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Loja_Quadrinhos.Services
{
    public class CarrinhoCompraService 
    {
        private AppDbContext Context;
        private IUnitOfWork UnitOfWork;
        private static Pedido Pedido;
        public CarrinhoCompraService(AppDbContext contexto, IUnitOfWork unitOfWork)
        {
            this.Context = contexto;
            this.UnitOfWork = unitOfWork;
            Pedido pedido = new Pedido();
            UnitOfWork.PedidoRepository.Add(pedido);
        }

        public static Pedido GetCarrinho(IServiceProvider services)
        {
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            int pedidoId = session.GetInt32("PedidoId") ?? Pedido.PedidoId;

            session.SetInt32("PedidoId", pedidoId);

            return Pedido;
        }

        public void AdicionarAoCarrinho(Produto produto, int quantidade)
        {
            PedidoItem pedidoItem = new PedidoItem(Pedido.PedidoId, produto.ProdutoId, quantidade);
            Pedido.AdicionarItem(pedidoItem);
        }

        public void RemoverDoCarrinho(Produto produto)
        {
            PedidoItem pedidoItem = new PedidoItem(Pedido.PedidoId, produto.ProdutoId);
            Pedido.RemoverItem(pedidoItem);
        }

        public void LimparCarrinho()
        {
            Pedido.PedidoItens.Clear();
        }

        public decimal GetCarrinhoCompraTotal()
        {
            Pedido.AtualizaTotal();
            return Pedido.PedidoTotal;
        }

        public int GetCarrinhoCompraQuantidade()
        {
            return Pedido.PedidoItens.Count;
        }

        public void FinalizaPedido(Usuario usuario)
        {
            Pedido.Usuario = usuario;
            Pedido.UsuarioId = usuario.Id;
        }
    }
}
