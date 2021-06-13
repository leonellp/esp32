using AutoMapper;
using esp32.DA.Abstraction.Models;
using esp32.WebApi.Abstraction.DTO;

namespace esp32.Mapper {
    public class Mappers : Profile {
        public Mappers() {

            // BALANÇA
            CreateMap<BalancaDTO, Balanca>().ReverseMap();
            CreateMap<BalancaInsertDTO, Balanca>()
                .ForMember(a => a.Produto, b => b.Ignore())
                .ReverseMap();
            
            // PRODUTO
            CreateMap<ProdutoDTO, Produto>()
                .ForMember(a => a.Balanca, b => b.MapFrom(c => c.Balanca))
                .ForMember(a => a.HistoricoProduto, b => b.MapFrom(c => c.HistoricoProduto))
                .ReverseMap()
                .ForMember(a => a.Balanca, b => b.MapFrom(c => c.Balanca))
                .ForMember(a => a.HistoricoProduto, b => b.MapFrom(c => c.HistoricoProduto));

            // PRODUTO INSERT
            CreateMap<ProdutoInsertDTO, Produto>()
                .ForMember(a => a.Balanca, b => b.Ignore())
                .ForMember(a => a.HistoricoProduto, b => b.Ignore())
                .ReverseMap();

            // HISTORICO PRODUTO
            CreateMap<HistoricoProdutoDTO, HistoricoProduto>().ReverseMap();
            CreateMap<HistoricoProdutoInsertDTO, HistoricoProduto>()
                .ForMember(a => a.Produto, b => b.Ignore())
                .ReverseMap();
        }
    }
}
