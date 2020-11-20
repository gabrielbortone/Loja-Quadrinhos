using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja_Quadrinhos.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        
        [Required]
        [Display(Name = "Título do quadrinho")]
        [StringLength(80, MinimumLength = 4)]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Autor da obra")]
        [StringLength(60, MinimumLength = 4)]
        public string Autor { get; set; }

        [Required]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        [Required]
        [Display(Name = "Descrição detalhada do Quadrinho")]
        [MinLength(20)]
        [MaxLength(200)]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Caminho Imagem")]
        [StringLength(200)]
        public string ImagemUrl { get; set; }

        [NotMapped]
        [DisplayName("Upload file")]
        public IFormFile ImageFile { get; set; }

        [Required]
        public decimal Preco { get; private set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int QuantidadeVendidos { get; private set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int QuantidadeEmEstoque { get; private set; }

        public Produto()
        {
            QuantidadeEmEstoque = 0;
            QuantidadeVendidos = 0;
        }

        public Produto(string titulo, string autor, int categoriaId, Categoria categoria, string descricao, string imagemUrl, decimal preco, int quantidadeVendidos, int quantidadeEmEstoque)
        {
            Titulo = titulo;
            Autor = autor;
            CategoriaId = categoriaId;
            Categoria = categoria;
            Descricao = descricao;
            ImagemUrl = imagemUrl;
            Preco = preco;
            QuantidadeVendidos = quantidadeVendidos;
            QuantidadeEmEstoque = quantidadeEmEstoque;
        }

        public Produto(int produtoId, string titulo, string autor, int categoriaId, Categoria categoria, string descricao, string imagemUrl, decimal preco, int quantidadeVendidos, int quantidadeEmEstoque)
        {
            ProdutoId = produtoId;
            Titulo = titulo;
            Autor = autor;
            CategoriaId = categoriaId;
            Categoria = categoria;
            Descricao = descricao;
            ImagemUrl = imagemUrl;
            Preco = preco;
            QuantidadeVendidos = quantidadeVendidos;
            QuantidadeEmEstoque = quantidadeEmEstoque;
        }

        public void AtualizarPreco(decimal novoPreco)
        {
            this.Preco = novoPreco;
        }
        public void Comprar(int quantidade)
        {
            if (quantidade > QuantidadeEmEstoque)
            {
                throw new Exception("Quantidade maior que o estoque!");
            }
            this.QuantidadeEmEstoque -= quantidade;
            this.QuantidadeVendidos += quantidade;
        }
    }
}
