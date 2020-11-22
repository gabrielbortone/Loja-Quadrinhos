using Loja_Quadrinhos.Context;
using Loja_Quadrinhos.Models;
using Loja_Quadrinhos.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Loja_Quadrinhos.Services
{
    public class CarrinhoCompraService
    {
        private IUnitOfWork UnitOfWork;
        private static Pedido Pedido;
        public CarrinhoCompraService(IUnitOfWork unitOfWork)
        {
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

        public IEnumerable<PedidoItem> GetItensDoCarrinho()
        {
            return Pedido.PedidoItens;
        }

        public void AdicionarItemNoCarrinhoCompra(int produtoId, int quantidade)
        {
            PedidoItem pedidoItem = new PedidoItem(Pedido.PedidoId, produtoId, quantidade);
            if (pedidoItem != null)
            {
                Pedido.AdicionarItem(pedidoItem);
            }
            else
            {
                throw new Exception("Não foi possível inserir item no carrinho!");
            }
        }

        public void RemoverItemDoCarrinhoCompra(int produtoId)
        {
            PedidoItem pedidoItem = new PedidoItem(Pedido.PedidoId, produtoId);
            if (pedidoItem != null)
            {
                Pedido.RemoverItem(pedidoItem);
            }
            else
            {
                throw new Exception("Não foi possível remover item do carrinho");
            }
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
            UnitOfWork.Commit();
        }

    }
}
