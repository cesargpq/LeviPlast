using AutoMapper;
using LeviPlast.Aplicacion.DTO;
using LeviPlast.Dominio.Entity;
namespace LeviPlast.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Customers,CustomersDTO>().ReverseMap();
            //CreateMap<Customers, CustomersDTO>().ReverseMap()
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId));

        }
    }
}
