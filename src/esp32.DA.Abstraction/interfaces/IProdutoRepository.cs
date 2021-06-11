using esp32.DA.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace esp32.DA.Abstraction.interfaces {
    public interface IProdutoRepository {
        IQueryable<Produto> List();
        Produto GetById(Guid Idproduto);
        void Insert(Produto Produto);
        void Delete(Guid Idproduto);
        void Update(Guid Idproduto, Produto produtoUpdate);
    }
}
