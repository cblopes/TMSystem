using AutoMapper;
using TMS.Api.DTOs;
using TMS.Business.Entities;

namespace TMS.Api.Configurations;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Pedido, PedidoDTO>().ReverseMap();
        CreateMap<Ocorrencia, OcorrenciaDTO>().ReverseMap();
        CreateMap<Ocorrencia, OcorrenciaPostDTO>().ReverseMap();
    }
}
