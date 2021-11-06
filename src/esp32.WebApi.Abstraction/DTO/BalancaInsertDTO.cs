using System;

namespace esp32.WebApi.Abstraction.DTO {
    public partial class BalancaInsertDTO {
        public Guid? ProdutoId { get; set; }        
        public string Nome { get; set; }
    }
}
