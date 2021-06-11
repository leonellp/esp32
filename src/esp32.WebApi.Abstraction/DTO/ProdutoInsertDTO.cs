using System;
using System.Collections.Generic;

#nullable disable

namespace esp32.WebApi.Abstraction.DTO {
    public partial class ProdutoInsertDTO {
        public Guid Idproduto { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }

        public virtual ICollection<BalancaDTO> Balanca { get; set; }
    }
}
