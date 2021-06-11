﻿using esp32.DA.Abstraction.interfaces;
using esp32.DA.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace esp32.DA {
   public class ProdutoRepository : IProdutoRepository{
        private readonly esp32Context Context;

        public ProdutoRepository(esp32Context context) {
            Context = context;
        }

        public void Delete(Guid Idproduto) {
            var produto = Context.Produto.Where(a => a.Idproduto == Idproduto).FirstOrDefault();
            Context.Produto.Remove(produto);
            Context.SaveChanges();
        }

        public Produto GetById(Guid Idproduto) {
            var produto = Context.Produto.Where(a => a.Idproduto == Idproduto).FirstOrDefault();
            return produto;
        }

        public void Insert(Produto Produto) {
            Context.Produto.Add(Produto);
            Context.SaveChanges();
        }

        public IQueryable<Produto> List() {
            return Context.Produto;
        }

        public void Update(Guid Idproduto, Produto produtoUpdate) {
            Produto produto = Context.Produto.Where(a => a.Idproduto == Idproduto).FirstOrDefault();

            produto.Nome = produtoUpdate.Nome;
            produto.Marca = produtoUpdate.Marca;

            Context.SaveChanges();
        }
    }
}