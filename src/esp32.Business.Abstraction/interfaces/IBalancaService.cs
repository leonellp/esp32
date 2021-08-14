using esp32.WebApi.Abstraction.DTO;
using System;

namespace esp32.Business.Abstraction.interfaces
{
    public interface IBalancaService
    {
        void Delete(Guid Idbalanca);
        BalancaDTO GetById(Guid Idbalanca);
        Guid Insert(Guid produtoId);
        Paginacao<BalancaDTO> List(
            int skip,
            int pageSize,
            bool count,
            string pesquisa = null
            );
        void Update(BalancaDTO balancaUpdate);
    }
}
