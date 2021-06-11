using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Scaffold
{
    public partial class Produto
    {
        public Produto()
        {
            Peso = new HashSet<Peso>();
        }

        public Guid Idproduto { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }

        public virtual ICollection<Peso> Peso { get; set; }
    }
}
