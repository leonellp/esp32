using System;

namespace esp32.WebApi.Abstraction.DTO {
    public partial class BalancaInsertDTO {
        public float Peso { get; set; }
        public DateTime Data { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
