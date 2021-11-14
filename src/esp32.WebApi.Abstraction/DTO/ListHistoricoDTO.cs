using System;

namespace esp32.WebApi.Abstraction.DTO
{
    public class ListHistoricoDTO
    {
        public Guid ProdutoId { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public int Count { get; set; }
    }
}
