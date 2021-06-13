using System;

namespace esp32.WebApi.Abstraction.DTO {
    public partial class HistoricoProdutoDTO
    {
        public Guid Idhistoricopeso { get; set; }
        public int Quantidade { get; set; }
        public Guid Produtoid { get; set; }
        public DateTime Data { get; set; }
        
    }
}
