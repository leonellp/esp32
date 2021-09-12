using esp32.WebApi.Abstraction.DTO;
using System;

namespace esp32.Business.Abstraction.interfaces {
    public interface IProdutoService {
        void Delete(Guid Idproduto);
        ProdutoDTO GetById(Guid Idproduto);
        void Insert(ProdutoInsertDTO Produto);
        Paginacao<ProdutoDTO> List(
            int skip,
            int pageSize,
            bool count,
            bool? inativos = null,
            string pesquisa = null
            );
        void Update(ProdutoUpdateDTO produtoUpdate);
    }
}
