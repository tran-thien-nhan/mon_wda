using AutoMapper;

namespace demo_DTO.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<productDTO, Product>();
            CreateMap<Product, productDTO>();
        }
    }
}
