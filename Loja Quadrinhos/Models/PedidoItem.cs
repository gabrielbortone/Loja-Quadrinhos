using System;
using System.ComponentModel.DataAnnotations;

namespace Loja_Quadrinhos.Models
{
    public class PedidoItem
    {
        public int PedidoItemId { get; set; }

        [Required]
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get;  set; }

        [Required]
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Informe uma quantidade válida!")]
        public int Quantidade { get; private set; }

        public void AumentarQuantidade()
        {
            this.Quantidade++;
        }

        public PedidoItem(int pedidoId, Pedido pedido, int produtoId, Produto produto, int quantidade)
        {
            PedidoId = pedidoId;
            Pedido = pedido;
            ProdutoId = produtoId;
            Produto = produto;
            Quantidade = quantidade;
        }

        public PedidoItem(int pedidoId, int produtoId, int quantidade)
        {
            PedidoId = pedidoId;
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }

        public PedidoItem(int pedidoItemId, int pedidoId, Pedido pedido, int produtoId, Produto produto, int quantidade)
        {
            PedidoItemId = pedidoItemId;
            PedidoId = pedidoId;
            Pedido = pedido;
            ProdutoId = produtoId;
            Produto = produto;
            Quantidade = quantidade;
        }

        public PedidoItem(int pedidoId, int produtoId)
        {
            PedidoId = pedidoId;
            ProdutoId = produtoId;
        }

        public override bool Equals(object obj)
        {
            return obj is PedidoItem item &&
                   PedidoId == item.PedidoId &&
                   ProdutoId == item.ProdutoId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PedidoId, ProdutoId);
        }
    }
}
