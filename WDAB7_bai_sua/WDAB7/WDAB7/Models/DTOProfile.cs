using AutoMapper;

namespace WDAB7.Models
{
    public class DTOProfile:Profile
    {
        public DTOProfile() {
            CreateMap<Product, ProductDTO>().ReverseMap();

        }
    }
}
