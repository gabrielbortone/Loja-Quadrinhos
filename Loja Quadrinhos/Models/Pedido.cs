using System;
using System.Collections.Generic;

namespace Loja_Quadrinhos.Models
{
    public class Pedido
    {
        public int PedidoId { get; private set; }

        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public virtual List<PedidoItem> PedidoItens { get; private set; }

        public decimal PedidoTotal { get; private set; }

        public DateTime DataPedido { get; private set; }
        public DateTime? PedidoEntregueEm { get; private set; }

        public void AdicionarItem(PedidoItem pedidoItem)
        {
            if (this.PedidoItens.Contains(pedidoItem))
            {
                PedidoItem aux = PedidoItens.Find(pi=>pi.PedidoId == pedidoItem.PedidoId && pi.ProdutoId == pedidoItem.ProdutoId);
                aux.AumentarQuantidade();
            }
            else
            {
                this.PedidoItens.Add(pedidoItem);
            }
            
        }

        public void RemoverItem(PedidoItem pedidoItem)
        {
            this.PedidoItens.Remove(pedidoItem);
        }

        public void AtualizaTotal()
        {
            this.PedidoTotal = 0;
            PedidoItens.ForEach(pitem => this.PedidoTotal += pitem.Produto.Preco * pitem.Quantidade);
        }

        public Pedido()
        {
            
        }
        public Pedido(int pedidoId)
        {
            this.PedidoId = pedidoId;
            this.PedidoTotal = 0;
            this.DataPedido = DateTime.Now;
        }

        public Pedido(string usuarioId, Usuario cliente, List<PedidoItem> pedidoItens, decimal pedidoTotal)
        {
            UsuarioId = usuarioId;
            Usuario = cliente;
            PedidoItens = pedidoItens;
            PedidoTotal = pedidoTotal;
            DataPedido = DateTime.Now;
        }

        public Pedido(int pedidoId, string usuarioId, Usuario cliente, List<PedidoItem> pedidoItens, decimal pedidoTotal, DateTime dataPedido)
        {
            PedidoId = pedidoId;
            UsuarioId = usuarioId;
            Usuario = cliente;
            PedidoItens = pedidoItens;
            PedidoTotal = pedidoTotal;
            DataPedido = dataPedido;
        }

        public Pedido(int pedidoId, string usuarioId, Usuario cliente, List<PedidoItem> pedidoItens, decimal pedidoTotal, DateTime dataPedido, DateTime? pedidoEntregueEm)
        {
            PedidoId = pedidoId;
            UsuarioId = usuarioId;
            Usuario = cliente;
            PedidoItens = pedidoItens;
            PedidoTotal = pedidoTotal;
            DataPedido = dataPedido;
            PedidoEntregueEm = pedidoEntregueEm;
        }


    }
}
