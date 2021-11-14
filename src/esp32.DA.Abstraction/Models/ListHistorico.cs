using System;

namespace esp32.DA.Abstraction.Models
{
    public class ListHistorico
    {
        public Guid ProdutoId { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public int Count { get; set; }
    }
}
