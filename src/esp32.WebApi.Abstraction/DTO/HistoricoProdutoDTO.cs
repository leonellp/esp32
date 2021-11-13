using System;

namespace esp32.WebApi.Abstraction.DTO {
    public partial class HistoricoProdutoDTO
    {
        public Guid Idhistoricoproduto { get; set; }
        public int Quantidade { get; set; }
        public Guid Produtoid { get; set; }
        public DateTime Data { get; set; }
        
    }
}
