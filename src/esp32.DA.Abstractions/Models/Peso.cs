using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Scaffold
{
    public partial class Peso
    {
        public Guid Idpeso { get; set; }
        public float Peso1 { get; set; }
        public DateTime data { get; set; }
        public Guid ProdutoId { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
