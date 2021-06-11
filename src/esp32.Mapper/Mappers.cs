using AutoMapper;
using esp32.DA.Abstraction.Models;
using esp32.WebApi.Abstraction.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace esp32.Mapper {
    public class Mappers : Profile {
        public Mappers() {
            CreateMap<BalancaDTO, Balanca>().ReverseMap();
            CreateMap<BalancaInsertDTO, Balanca>().ReverseMap();

            CreateMap<ProdutoDTO, Produto>()
                .ForMember(a => a.Balanca, b => b.MapFrom(c => c.Balanca))
                .ReverseMap()
                .ForMember(a => a.Balanca, b => b.MapFrom(c => c.Balanca));

            CreateMap<ProdutoInsertDTO, Produto>()
                .ForMember(a => a.Balanca, b => b.Ignore())
                .ReverseMap();            
        }
    }
}
