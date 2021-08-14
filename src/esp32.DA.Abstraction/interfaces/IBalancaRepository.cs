using esp32.DA.Abstraction.Models;
using System;
using System.Linq;

namespace esp32.DA.Abstraction.interfaces {
    public interface IBalancaRepository {
        void Delete(Guid Idbalanca);
        Balanca GetById(Guid Idbalanca);
        Guid Insert(Balanca Balanca);
        IQueryable<Balanca> List();
        void Update(Balanca balancaUpdate);
    }
}
