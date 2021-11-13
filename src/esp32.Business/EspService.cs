using AutoMapper;
using esp32.Business.Abstraction.interfaces;
using esp32.DA.Abstraction.interfaces;
using esp32.DA.Abstraction.Models;
using esp32.WebApi.Abstraction.DTO;
using System;
using System.Linq;

namespace esp32.Business
{
    public class EspService : IEspService
    {
        private readonly IBalancaRepository balancaService;
        private readonly IProdutoService produtoService;
        private readonly IHistoricoProdutoRepository historicoRepository;
        private readonly IMapper mapper;
        public float Peso;
        public EspService(IBalancaRepository _balancaRepository, IProdutoService _produtoService, IHistoricoProdutoRepository _historicoRepository, IMapper _mapper) {
            balancaService = _balancaRepository;
            produtoService = _produtoService;
            historicoRepository = _historicoRepository;
            mapper = _mapper;
        }
        public void Update(EspDTO esp) {
            var balanca = balancaService.GetById(esp.Idbalanca);
            if(balanca == null)
                throw new Exception("Balanca não encontrada");

            var produto = produtoService.GetById(balanca.ProdutoId.Value);
            if(produto == null)
                throw new Exception("Produto não encontrada");

            Peso = esp.Peso;
            float quantidade = 0.0F;

            if(produto.Peso > 0) {
                quantidade = (Peso / produto.Peso);
            }

            if((int) quantidade == balanca.Quantidade) {
                return;
            }

            balanca.Quantidade = (int) quantidade;
            balanca.Peso = Peso;
            balancaService.Update(balanca);

            HistoricoProduto historico = new HistoricoProduto();
            historico.Idhistoricoproduto = Guid.NewGuid();
            historico.Quantidade = (int) quantidade;
            historico.Produtoid = produto.Idproduto;
            historico.Data = DateTime.Now;

            historicoRepository.Insert(historico);
        }

        public float PesobalancaGet() {
            return Peso;
        }
    }
}
