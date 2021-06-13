using esp32.DA.Abstraction.interfaces;
using esp32.DA.Abstraction.Models;
using System;
using System.Linq;

namespace esp32.DA {
    public class BalancaRepository : IBalancaRepository {

        private readonly esp32Context Context;

        public BalancaRepository(esp32Context context) {
            Context = context;
        }

        public void Delete(Guid Idbalanca) {
            var balanca = Context.Balanca.Where(a => a.Idbalanca == Idbalanca).FirstOrDefault();
            Context.Balanca.Remove(balanca);
            Context.SaveChanges();
        }

        public Balanca GetById(Guid Idbalanca) {
            var balanca = Context.Balanca.Where(a => a.Idbalanca == Idbalanca).FirstOrDefault();
            return balanca;
        }

        public void Insert(Balanca Balanca) {
            Context.Balanca.Add(Balanca);
            Context.SaveChanges();
        }

        public IQueryable<Balanca> List() {
            return Context.Balanca;
        }

        public void Update(Balanca balancaUpdate) {
            Balanca balanca = Context.Balanca.Where(a => a.Idbalanca == balancaUpdate.Idbalanca).FirstOrDefault();

            balanca.Peso = balancaUpdate.Peso;
            balanca.Data = balancaUpdate.Data;
            balanca.ProdutoId = balancaUpdate.ProdutoId;
            balanca.Quantidade = balancaUpdate.Quantidade;

            Context.SaveChanges();
        }
    }
}
