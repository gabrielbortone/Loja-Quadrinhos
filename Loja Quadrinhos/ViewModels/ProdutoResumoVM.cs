using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_Quadrinhos.ViewModels
{
    public class ProdutoResumoVM
    {
        public int ProdutoId { get; private set; }
        public string ImagemUrl { get; private set; }
        public string Titulo { get; private set; }
        public decimal Preco { get; private set; }

    }
}
