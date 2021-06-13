using System;

namespace esp32.WebApi.Abstraction.DTO {
    public partial class HistoricoProdutoInsertDTO {
        public int Quantidade { get; set; }
        public Guid Produtoid { get; set; }
        public DateTime Data { get; set; }

    }
}
