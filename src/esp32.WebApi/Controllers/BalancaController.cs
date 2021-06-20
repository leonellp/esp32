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
    public class BalancaController : ControllerBase
    {
        private readonly IBalancaService balancaService;
        public BalancaController(IBalancaService Service) {
            this.balancaService = Service;
        }

        [HttpGet]
        [Route("")]
        public Paginacao<BalancaDTO> List(
            int skip = 0,
            int pageSize = 5,
            bool count = false,
            string pesquisa = null
            ) {
            return balancaService.List(skip, pageSize, count, pesquisa);
        }

        [HttpGet]
        [Route("{id}")]
        public BalancaDTO Get(Guid id) {
            return balancaService.GetById(id);
        }

        [HttpPost]
        public void Insert(BalancaInsertDTO balanca) {
            balancaService.Insert(balanca);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id) {
            balancaService.Delete(id);
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(BalancaDTO balanca) {
            balancaService.Update(balanca);
        }
    }
}
