using Xunit;
using TrueSneakersWeb.Domain;
using System;

namespace TrueSneakersWeb.Tests
{
    public class TestesDeDominio
    {
        [Fact]
        public void CriarTenis_DadosValidos_Sucesso()
        {
            var tenis = new Produto("Nike Dunk", 800m, 10);
            Assert.Equal("Nike Dunk", tenis.Nome);
        }

        [Fact]
        public void CriarTenis_PrecoNegativo_Erro()
        {
            Assert.Throws<Exception>(() => new Produto("Nike Dunk", -10m, 10));
        }

        [Fact]
        public void CriarTenis_EstoqueNegativo_Erro()
        {
            Assert.Throws<Exception>(() => new Produto("Nike Dunk", 800m, -5));
        }

        [Fact]
        public void CriarTenis_SemNome_Erro()
        {
            Assert.Throws<Exception>(() => new Produto("", 800m, 10));
        }

        [Fact]
        public void Produto_DeveComecar_Ativo()
        {
            var tenis = new Produto("Adidas Forum", 600m, 5);
            Assert.True(tenis.Ativo);
        }
    }
}