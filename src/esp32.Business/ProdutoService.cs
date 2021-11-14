using AutoMapper;
using esp32.Business.Abstraction.interfaces;
using esp32.DA.Abstraction.interfaces;
using esp32.WebApi.Abstraction.DTO;
using System;
using System.Linq;
using esp32.DA.Abstraction.Models;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;

namespace esp32.Business
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;
        private IMapper mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper) {
            this.produtoRepository = produtoRepository;
            this.mapper = mapper;
        }
        public void Delete(Guid Idproduto) {
            produtoRepository.Delete(Idproduto);
        }

        public ProdutoDTO GetById(Guid Idproduto) {
            return mapper.Map<ProdutoDTO>(produtoRepository.GetById(Idproduto));
        }

        public Guid Insert(ProdutoInsertDTO Produto) {
            var produto = mapper.Map<Produto>(Produto);

            produto.Idproduto = Guid.NewGuid();

            return produtoRepository.Insert(produto);
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
            if(inativos == true) {
                produtos = produtos.Where(a => a.Inativo != null);
            } else {
                produtos = produtos.Where(a => a.Inativo == null);
            }

            if(pesquisa != null) {
                produtos = produtos.Where(a =>
                a.Nome.ToUpper().Contains(pesquisa.ToUpper()) ||
                a.Marca.ToUpper().Contains(pesquisa.ToUpper())
                );
            }

            if(count) {
                nCount = produtos.Count();
            }

            if(skip < 0)
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

        public Paginacao<HistoricoProdutoDTO> HistoricoProduto(Guid ProdutoId, DateTime? Inicio, DateTime? Fim) {
            if(ProdutoId == null)
                throw new Exception("Id do Produto não pode ser nulo");

            var historico = produtoRepository.HistoricoProduto(ProdutoId);

            if(Inicio != null)
                historico = historico.Where(x => x.Data >= Inicio);

            if(Fim != null)
                historico = historico.Where(x => x.Data <= Fim);

            historico = historico.OrderByDescending(a => a.Data);

            return new Paginacao<HistoricoProdutoDTO>() {
                Values = historico.ProjectTo<HistoricoProdutoDTO>(mapper.ConfigurationProvider).ToArray(),
                Count = historico.Count()
            };
        }
    }
}
