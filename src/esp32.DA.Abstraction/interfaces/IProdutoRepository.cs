using esp32.DA.Abstraction.Models;
using esp32.WebApi.Abstraction.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace esp32.DA.Abstraction.interfaces {
    public interface IProdutoRepository {
        void Delete(Guid Idproduto);
        Produto GetById(Guid Idproduto);
        Guid Insert(Produto Produto);
        IQueryable<Produto> List();
        void Update(Produto produtoUpdate);
        IQueryable<HistoricoProduto> HistoricoProduto(Guid ProdutoId);
    }
}
