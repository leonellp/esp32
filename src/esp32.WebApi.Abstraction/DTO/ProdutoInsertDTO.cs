using System;

namespace esp32.WebApi.Abstraction.DTO {
    public partial class ProdutoInsertDTO {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public float Peso { get; set; }
        public DateTime? Inativo { get; set; }
    }
}
