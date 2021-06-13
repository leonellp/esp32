using esp32.WebApi.Abstraction.DTO;
using System;

namespace esp32.Business.Abstraction.interfaces {
    public interface IBalancaService {
        void Delete(Guid Idbalanca);
        BalancaDTO GetById(Guid Idbalanca);
        void Insert(BalancaDTO Balanca);
        Paginacao<BalancaDTO> List();
        void Update(BalancaDTO balancaUpdate);
    }
}
