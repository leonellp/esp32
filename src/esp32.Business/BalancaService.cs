using AutoMapper;
using esp32.Business.Abstraction.interfaces;
using esp32.DA.Abstraction.interfaces;
using esp32.WebApi.Abstraction.DTO;
using System;
using System.Linq;
using esp32.DA.Abstraction.Models;
using AutoMapper.QueryableExtensions;

namespace esp32.Business {
    public class BalancaService : IBalancaService {
        private readonly IBalancaRepository balancaRepository;
        private IMapper mapper;

        public BalancaService(IBalancaRepository balancaRepository, IMapper mapper) {
            this.balancaRepository = balancaRepository;
            this.mapper = mapper;
        }
        public void Delete(Guid Idbalanca) {
            balancaRepository.Delete(Idbalanca);
        }

        public BalancaDTO GetById(Guid Idbalanca) {
            return mapper.Map<BalancaDTO>(balancaRepository.GetById(Idbalanca));
        }

        public void Insert(BalancaDTO Balanca) {
            var balanca = mapper.Map<Balanca>(Balanca);
            balanca.Idbalanca = Guid.NewGuid();
            balancaRepository.Insert(balanca);
        }

        public Paginacao<BalancaDTO> List(
            int skip,
            int pageSize,
            bool count,            
            string pesquisa = null
            ) {
            int? nCount = null;

            var balanca = balancaRepository.List();
            
            if (pesquisa != null) {
                balanca = balanca.Where(a =>
                a.Produto.Nome.ToUpper().Contains(pesquisa.ToUpper()) ||
                a.Produto.Marca.ToUpper().Contains(pesquisa.ToUpper())                
                );
            }

            if (count) {
                nCount = balanca.Count();
            }

            if (skip < 0)
                skip = 0;
            balanca = balanca.OrderBy(a => a.Produto.Nome);
            balanca = balanca.Skip(skip).Take(pageSize);

            return new Paginacao<BalancaDTO>() {
                Values = balanca.ProjectTo<BalancaDTO>(mapper.ConfigurationProvider).ToArray(),
                Count = nCount
            };
        }

        public void Update(BalancaDTO balancaUpdate) {
            balancaRepository.Update(mapper.Map<Balanca>(balancaUpdate));
        }
    }
}
