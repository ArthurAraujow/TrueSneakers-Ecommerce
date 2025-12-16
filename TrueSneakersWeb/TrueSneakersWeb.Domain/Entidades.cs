using System;
using System.Collections.Generic;

namespace TrueSneakersWeb.Domain
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Marca { get; private set; }
        public decimal Preco { get; private set; }
        public string? UrlImagem { get; private set; }
        public string Tamanhos { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public bool Ativo { get; private set; } = true;

        protected Produto() { }

        public Produto(string nome, string marca, decimal preco, string? urlImagem, string tamanhos, int quantidade)
        {
            
            // 1. Não deixa nome vazio
            if (string.IsNullOrEmpty(nome)) 
                throw new Exception("Nome é obrigatório");

            // 2. Não deixa marca vazia
            if (string.IsNullOrEmpty(marca)) 
                throw new Exception("Marca é obrigatória");

            // 3. Não deixa preço negativo ou zero
            if (preco <= 0) 
                throw new Exception("Preço deve ser maior que zero");

            // 4. Não deixa estoque negativo
            if (quantidade < 0) 
                throw new Exception("Estoque não pode ser negativo");

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
        public string Perfil { get; set; } 
    }
}