using Loja_Quadrinhos.Models.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Loja_Quadrinhos.Models
{
    public class Usuario : IdentityUser
    {
        [Required]
        public Name Nome { get; private set; }
        [Required]
        public string Cpf { get; private set; }
        [Required]
        public Endereco Endereco { get; private set; }

        public Usuario()
        {

        }
        public Usuario(Name nome, string username,string email, string telefone, string cpf, Endereco endereco)
        {
            Nome = nome;
            Cpf = cpf;
            UserName = username;
            Email = email;
            PhoneNumber = telefone;
            Endereco = endereco;
        }

    }
}
