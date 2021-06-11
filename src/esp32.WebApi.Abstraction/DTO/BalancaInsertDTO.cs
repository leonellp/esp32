using System;
using System.Collections.Generic;

#nullable disable

namespace esp32.WebApi.Abstraction.DTO {
    public partial class BalancaInsertDTO {
        public Guid Idbalanca { get; set; }
        public float Peso { get; set; }
        public DateTime Data { get; set; }
        public Guid ProdutoId { get; set; }
    }
}
