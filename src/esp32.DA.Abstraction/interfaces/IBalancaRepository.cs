using esp32.DA.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace esp32.DA.Abstraction.interfaces {
    public interface IBalancaRepository {
        IQueryable<Balanca> List();
        Balanca GetById(Guid Idbalanca);
        void Insert(Balanca Balanca);
        void Delete(Guid Idbalanca);
        void Update(Guid Idbalanca, Balanca balancaUpdate);
    }
}
