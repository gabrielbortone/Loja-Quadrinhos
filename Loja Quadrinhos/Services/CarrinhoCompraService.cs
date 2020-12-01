﻿using Loja_Quadrinhos.Context;
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
        private Pedido Pedido;
        public CarrinhoCompraService(IUnitOfWork unitOfWork, IServiceProvider services)
        {
            this.UnitOfWork = unitOfWork;
            Pedido = new Pedido();
            UnitOfWork.PedidoRepository.Add(Pedido);

            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            int pedidoId = session.GetInt32("PedidoId") ?? Pedido.PedidoId;

            session.SetInt32("PedidoId", pedidoId);
        }


        public List<PedidoItem> GetItensDoCarrinho()
        {
            return Pedido.PedidoItens;
        }

        public void AdicionarItemNoCarrinhoCompra(int produtoId, int quantidade)
        {
            PedidoItem pedidoItem = new PedidoItem(Pedido.PedidoId, produtoId, quantidade);
            Produto produto = UnitOfWork.ProdutoRepository.GetById(produtoId);

            if (pedidoItem != null)
            {
                if(produto.QuantidadeEmEstoque > quantidade)
                {
                    UnitOfWork.PedidoItemRepository.Add(pedidoItem);
                    Pedido.AdicionarItem(pedidoItem);
                }
                else
                {
                    throw new Exception("O número de produto é menor que o estoque");
                }
                
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
                UnitOfWork.PedidoItemRepository.Delete(pedidoItem);
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
