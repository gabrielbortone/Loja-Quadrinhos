using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Loja_Quadrinhos.Models.ValueObjects
{
    public struct Endereco
    {
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }

        public Endereco(string logradouro, string bairro, string cidade, string estado, string pais)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }
    }
}
