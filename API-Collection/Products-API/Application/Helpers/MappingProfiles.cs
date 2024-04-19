using AutoMapper;
using Products_API.Application.Products.DTOs;
using Products_API.Application.Specifications.DTOs;
using Products_API.Domain.Entities;

namespace Products_API.Application.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(productResponse => productResponse.Specifications,
                options => options
                    .MapFrom(product => product.Specifications.Select(spec => new SpecificationResponse(spec.Title, spec.Value))));
        CreateMap<Specification, SpecificationResponse>();
    }
}