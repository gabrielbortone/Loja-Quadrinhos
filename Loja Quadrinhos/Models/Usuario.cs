using Loja_Quadrinhos.Models.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Loja_Quadrinhos.Models
{
    public class Usuario : IdentityUser
    {
        public Name Nome { get; private set; }
        public string Cpf { get; private set; }
        public Endereco Endereco { get; private set; }

    }
}
