﻿using esp32.DA.Abstraction.interfaces;
using esp32.DA.Abstraction.Models;
using esp32.WebApi.Abstraction.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace esp32.DA
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly esp32Context Context;

        public ProdutoRepository(esp32Context context) {
            Context = context;
        }

        public void Delete(Guid Idproduto) {
            var produto = Context.Produto.Where(a => a.Idproduto == Idproduto).FirstOrDefault();
            produto.Inativo = DateTime.Now;
            Context.SaveChanges();
        }

        public Produto GetById(Guid Idproduto) {
            var produto = Context.Produto.Where(a => a.Idproduto == Idproduto).FirstOrDefault();
            return produto;
        }

        public Guid Insert(Produto Produto) {
            Context.Produto.Add(Produto);
            Context.SaveChanges();
            return Produto.Idproduto;
        }

        public IQueryable<Produto> List() {
            return Context.Produto;
        }

        public void Update(Produto produtoUpdate) {
            Produto produto = Context.Produto.Where(a => a.Idproduto == produtoUpdate.Idproduto).FirstOrDefault();

            produto.Nome = produtoUpdate.Nome;
            produto.Marca = produtoUpdate.Marca;
            produto.Peso = produtoUpdate.Peso;
            produto.Inativo = produtoUpdate.Inativo;

            Context.SaveChanges();
        }

        public IQueryable<HistoricoProduto> HistoricoProduto(Guid ProdutoId) {
            var historico = Context.HistoricoProduto.Where(a => a.Produtoid == ProdutoId);
            return historico;
        }
    }
}
