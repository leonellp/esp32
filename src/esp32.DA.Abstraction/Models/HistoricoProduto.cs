using System;
using System.Collections.Generic;

#nullable disable

namespace esp32.DA.Abstraction.Models
{
    public partial class HistoricoProduto
    {
        public Guid Idhistoricoproduto { get; set; }
        public int Quantidade { get; set; }
        public Guid Produtoid { get; set; }
        public DateTime Data { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
