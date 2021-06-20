using esp32.WebApi.Abstraction.DTO;

namespace esp32.Business.Abstraction.interfaces {
    public interface IEspService {
        void Update(EspDTO esp);
        void PesobalancaInsert(float Pesoatual);
        float PesobalancaGet();
    }
}
