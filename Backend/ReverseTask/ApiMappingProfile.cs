using AutoMapper;
using ReverseTask.Models;
using ReverseTask.Requests;

namespace ReverseTask;

public class ApiMappingProfile : Profile
{
    public ApiMappingProfile()
    {
        CreateMap<ConcentrationRequest, Concentration>();
        CreateMap<DataRequest, Data>();
    }
}