using AutoMapper;
using OrderService.Domain.Models;
using OrderService.Services.API.Models;

namespace OrderService.Services.API.Configuration.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<OrderViewModel, Order>();
        }
    }
}
