using esp32.DA.Abstraction.interfaces;
using esp32.DA.Abstraction.Models;
using System;
using System.Linq;

namespace esp32.DA {
    public class HistoricoProdutoRepository : IHistoricoProdutoRepository {

        private readonly esp32Context Context;

        public HistoricoProdutoRepository(esp32Context context) {
            Context = context;
        }

        public void Delete(Guid Idhistorico) {
            var historico = Context.HistoricoProduto.Where(a => a.Idhistoricoproduto == Idhistorico).FirstOrDefault();
            Context.HistoricoProduto.Remove(historico);
            Context.SaveChanges();
        }

        public HistoricoProduto GetById(Guid Idhistorico) {
            var historico = Context.HistoricoProduto.Where(a => a.Idhistoricoproduto == Idhistorico).FirstOrDefault();
            return historico;
        }

        public void Insert(HistoricoProduto historico) {
            Context.HistoricoProduto.Add(historico);
            Context.SaveChanges();
        }

        public IQueryable<HistoricoProduto> List() {
            return Context.HistoricoProduto;
        }

        public void Update(HistoricoProduto historicoUpdate) {
            HistoricoProduto historico = Context.HistoricoProduto.Where(a => a.Idhistoricoproduto == historicoUpdate.Idhistoricoproduto).FirstOrDefault();

            historico.Quantidade = historicoUpdate.Quantidade;
            historico.Produtoid = historicoUpdate.Produtoid;
            historico.Data = historicoUpdate.Data;

            Context.SaveChanges();
        }
    }
}
