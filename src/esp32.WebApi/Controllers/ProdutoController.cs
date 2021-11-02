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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService produtoService;
        public ProdutoController(IProdutoService service) {
            this.produtoService = service;
        }

        [HttpGet]
        [Route("")]
        public Paginacao<ProdutoDTO> List(
            int skip = 0,
            int pageSize = 5,
            bool count = false,
            bool? inativos = null,
            string pesquisa = null
            ) {
            return produtoService.List(skip, pageSize, count, inativos, pesquisa);
        }

        [HttpGet]
        [Route("{id}")]
        public ProdutoDTO Get(Guid id) {
            return produtoService.GetById(id);
        }

        [HttpPost]
        public Guid Insert(ProdutoInsertDTO produto) {
            return produtoService.Insert(produto);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(Guid id) {
            produtoService.Delete(id);
        }

        [HttpPut]
        [Route("{id}")]
        public void Update(ProdutoUpdateDTO produto) {
            produtoService.Update(produto);
        }
    }
}
