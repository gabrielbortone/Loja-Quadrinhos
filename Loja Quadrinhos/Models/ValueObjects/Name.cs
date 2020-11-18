namespace Loja_Quadrinhos.Models.ValueObjects
{
    public struct Name
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public Name(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

    }
}
