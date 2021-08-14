using esp32.Business.Abstraction.interfaces;
using esp32.WebApi.Abstraction.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace esp32.WebApi.Controllers
{
    [ApiController]
    [Route("/v1/[controller]")]
    public class EspController : ControllerBase
    {
        private readonly IEspService espService;
        public EspController(IEspService Service) {
            this.espService = Service;
        }

        [HttpPost]
        [Route("{idbalanca}")]
        public void Update(Guid idbalanca, float peso) {
            EspDTO esp = new EspDTO();

            esp.Idbalanca = idbalanca;
            esp.Peso = peso;

            espService.Update(esp);
        }        
    }
}
