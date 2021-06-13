using esp32.DA.Abstraction.Models;
using System;
using System.Linq;

namespace esp32.DA.Abstraction.interfaces {
    public interface IHistoricoProdutoRepository {
        void Delete(Guid Idhistorico);
        HistoricoProduto GetById(Guid Idhistorico);
        void Insert(HistoricoProduto Historico);
        IQueryable<HistoricoProduto> List();
        void Update(HistoricoProduto historicoUpdate);
    }
}
