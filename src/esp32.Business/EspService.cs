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
        private readonly IBalancaRepository balancaRepository;
        private readonly IProdutoRepository produtoRepository;
        private readonly IHistoricoProdutoRepository historicoRepository;
        public float Peso;
        public EspService(IBalancaRepository balancaRepository, IProdutoRepository produtoRepository, IHistoricoProdutoRepository historicoRepository) {
            this.balancaRepository = balancaRepository;
            this.produtoRepository = produtoRepository;
            this.historicoRepository = historicoRepository;
        }
        public void Update(EspDTO esp) {
            var balanca = balancaRepository.GetById(esp.Idbalanca);
            var produto = produtoRepository.List().Where(a => a.Idproduto == balanca.ProdutoId).FirstOrDefault();
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
            balancaRepository.Update(balanca);

            HistoricoProduto historico = new HistoricoProduto();
            historico.Idhistoricoproduto = Guid.NewGuid();
            historico.Quantidade = (int) quantidade;
            historico.Produtoid = produto.Idproduto;
            historico.Data = DateTime.Today;
            historico.Produto = produto;

            historicoRepository.Insert(historico);
        }

        public float PesobalancaGet() {
            return Peso;
        }
    }
}
