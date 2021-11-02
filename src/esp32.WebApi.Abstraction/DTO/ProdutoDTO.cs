using System;
using System.Collections.Generic;

namespace esp32.WebApi.Abstraction.DTO {
    public partial class ProdutoDTO
    {
        public Guid Idproduto { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public float Peso { get; set; }
        public DateTime? Inativo { get; set; }

        public virtual BalancaDTO[] Balanca { get; set; }
    }
}
