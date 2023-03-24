using AutoMapper;
using DsK.Application.Features.Brands.Commands.AddEdit;
using DsK.Application.Features.Brands.Queries.GetById;
using DsK.Domain.Entities;

namespace DsK.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {        
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();  
            CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
        }
        
    }
}
