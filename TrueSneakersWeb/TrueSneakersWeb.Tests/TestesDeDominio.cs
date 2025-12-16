using Xunit;
using TrueSneakersWeb.Domain;
using System;

namespace TrueSneakersWeb.Tests
{
    public class TestesDeDominio
    {
        // TESTE 1: Criar produto completo (com imagem)
        [Fact]
        public void CriarProduto_ComDadosValidos_DeveFuncionar()
        {
            // Ordem: Nome, Marca, Preco, UrlImagem, Tamanhos, Quantidade
            var tenis = new Produto("Nike Air Jordan", "Nike", 1200.00m, "foto.jpg", "39,40,41", 10);
            
            Assert.Equal("Nike Air Jordan", tenis.Nome);
            Assert.Equal("foto.jpg", tenis.UrlImagem);
        }

        // TESTE 2: Criar produto SEM IMAGEM (Passando null)
        [Fact]
        public void CriarProduto_SemImagem_DeveFuncionar()
        {
            // Note o 'null' na 4ª posição. É obrigatório passar, mesmo que seja null.
            var tenis = new Produto("Nike Simples", "Nike", 500.00m, null, "40", 10);
            
            Assert.Null(tenis.UrlImagem); 
        }

        // TESTE 3: Validar Preço Negativo
        [Fact]
        public void CriarProduto_ComPrecoNegativo_DeveDarErro()
        {
            // Passando null na imagem para focar no erro de preço
            Assert.Throws<Exception>(() => new Produto("Tênis Ruim", "Genérica", -50.00m, null, "40", 10));
        }

        // TESTE 4: Validar Nome Vazio
        [Fact]
        public void CriarProduto_SemNome_DeveDarErro()
        {
            Assert.Throws<Exception>(() => new Produto("", "Genérica", 500.00m, null, "40", 10));
        }

        // TESTE 5: Validar Estoque Negativo
        [Fact]
        public void CriarProduto_EstoqueNegativo_DeveDarErro()
        {
            Assert.Throws<Exception>(() => new Produto("Nike", "Nike", 500.00m, null, "40", -1));
        }
    }
}