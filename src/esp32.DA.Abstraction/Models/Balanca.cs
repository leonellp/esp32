using System;
using System.Collections.Generic;

#nullable disable

namespace esp32.DA.Abstraction.Models
{
    public partial class Balanca
    {
        public Guid Idbalanca { get; set; }
        public float Peso { get; set; }
        public DateTime Data { get; set; }
        public Guid? ProdutoId { get; set; }
        public int Quantidade { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
