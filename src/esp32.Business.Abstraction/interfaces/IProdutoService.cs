using esp32.WebApi.Abstraction.DTO;
using System;
using System.Collections.Generic;

namespace esp32.Business.Abstraction.interfaces
{
    public interface IProdutoService
    {
        void Delete(Guid Idproduto);
        ProdutoDTO GetById(Guid Idproduto);
        Guid Insert(ProdutoInsertDTO Produto);
        Paginacao<ProdutoDTO> List(
            int skip,
            int pageSize,
            bool count,
            bool? inativos = null,
            string pesquisa = null
            );
        void Update(ProdutoUpdateDTO produtoUpdate);
        Paginacao<HistoricoProdutoDTO> HistoricoProduto(Guid ProdutoId, DateTime? Inicio, DateTime? Fim);
    }
}
