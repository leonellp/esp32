using System.Collections.Generic;

namespace esp32.WebApi.Abstraction.DTO {
    public class Paginacao<T> {
        public IEnumerable<T> Values { get; set; }
        public int? Count { get; set; }

    }
}
