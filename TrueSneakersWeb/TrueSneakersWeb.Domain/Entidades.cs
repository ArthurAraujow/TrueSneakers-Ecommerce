using System;
using System.Collections.Generic;

namespace TrueSneakersWeb.Domain
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Marca { get; private set; }      // NOVO
        public decimal Preco { get; private set; }
        public string UrlImagem { get; private set; }  // NOVO
        public string Tamanhos { get; private set; }   // NOVO (Ex: "39, 40, 41")
        public int QuantidadeEstoque { get; private set; }
        public bool Ativo { get; private set; } = true;

        protected Produto() { }

        public Produto(string nome, string marca, decimal preco, string urlImagem, string tamanhos, int quantidade)
        {
            Nome = nome;
            Marca = marca;
            Preco = preco;
            UrlImagem = urlImagem;
            Tamanhos = tamanhos;
            QuantidadeEstoque = quantidade;
        }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; } // "Gerente" ou "Vendedor"
    }
}