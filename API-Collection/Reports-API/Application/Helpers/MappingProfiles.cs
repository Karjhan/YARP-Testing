using AutoMapper;
using Reports_API.Application.Reports.DTOs;
using Reports_API.Domain.Entities;

namespace Reports_API.Application.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Report, ReportResponse>();
    }
}