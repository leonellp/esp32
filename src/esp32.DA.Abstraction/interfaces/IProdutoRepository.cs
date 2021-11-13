using esp32.DA.Abstraction.Models;
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
        List<HistoricoProduto> HistoricoProduto(Guid Idproduto);
    }
}
