using System;
using System.Collections.Generic;

#nullable disable

namespace esp32.DA.Abstraction.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Balanca = new HashSet<Balanca>();
            HistoricoProduto = new HashSet<HistoricoProduto>();
        }

        public Guid Idproduto { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public float Peso { get; set; }
        public DateTime? Inativo { get; set; }

        public virtual ICollection<Balanca> Balanca { get; set; }
        public virtual ICollection<HistoricoProduto> HistoricoProduto { get; set; }
    }
}
