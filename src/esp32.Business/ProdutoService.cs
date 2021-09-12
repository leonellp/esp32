using AutoMapper;
using esp32.Business.Abstraction.interfaces;
using esp32.DA.Abstraction.interfaces;
using esp32.WebApi.Abstraction.DTO;
using System;
using System.Linq;
using esp32.DA.Abstraction.Models;
using AutoMapper.QueryableExtensions;

namespace esp32.Business {
    public class ProdutoService : IProdutoService {
        private readonly IProdutoRepository produtoRepository;
        private readonly IEspService espService;
        private IMapper mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper, IEspService espService) {
            this.produtoRepository = produtoRepository;
            this.espService = espService;
            this.mapper = mapper;            
        }
        public void Delete(Guid Idproduto) {
            produtoRepository.Delete(Idproduto);
        }

        public ProdutoDTO GetById(Guid Idproduto) {
            return mapper.Map<ProdutoDTO>(produtoRepository.GetById(Idproduto));
        }

        public void Insert(ProdutoInsertDTO Produto) {
            var produto = mapper.Map<Produto>(Produto);
            float pesoAtual = espService.PesobalancaGet();

            produto.Peso = pesoAtual;
            produto.Idproduto = Guid.NewGuid();

            produtoRepository.Insert(produto);
        }

        public Paginacao<ProdutoDTO> List(
            int skip,
            int pageSize,
            bool count,
            bool? inativos = null,
            string pesquisa = null
            ) {
            int? nCount = null;

            var produtos = produtoRepository.List();
            if (inativos == true) {
                produtos = produtos.Where(a => a.Inativo != null);
            } else {
                produtos = produtos.Where(a => a.Inativo == null);
            }

            if (pesquisa != null) {
                produtos = produtos.Where(a =>
                a.Nome.ToUpper().Contains(pesquisa.ToUpper()) ||
                a.Marca.ToUpper().Contains(pesquisa.ToUpper())                
                );
            }

            if (count) {
                nCount = produtos.Count();
            }

            if (skip < 0)
                skip = 0;
            produtos = produtos.OrderBy(a => a.Nome);
            produtos = produtos.Skip(skip).Take(pageSize);

            return new Paginacao<ProdutoDTO>() {
                Values = produtos.ProjectTo<ProdutoDTO>(mapper.ConfigurationProvider).ToArray(),
                Count = nCount
            };
        }

        public void Update(ProdutoUpdateDTO produtoUpdate) {
            produtoRepository.Update(mapper.Map<Produto>(produtoUpdate));
        }
    }
}
