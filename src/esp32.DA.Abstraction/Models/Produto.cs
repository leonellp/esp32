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
        }

        public Guid Idproduto { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }

        public virtual ICollection<Balanca> Balanca { get; set; }
    }
}
