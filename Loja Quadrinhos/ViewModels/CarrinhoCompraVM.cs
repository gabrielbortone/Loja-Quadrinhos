using Loja_Quadrinhos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_Quadrinhos.ViewModels
{
    public class CarrinhoCompraVM
    {
        public List<PedidoItem> CarrinhoCompraItens { get; set; }
        public int QuantidadeItens { get; set; }
        public decimal Total { get; set; }

    }
}
