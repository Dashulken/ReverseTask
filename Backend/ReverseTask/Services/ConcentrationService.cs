using AutoMapper;
using ReverseTask.Models;
using ReverseTask.Requests;

namespace ReverseTask.Services;

public class ConcentrationService
{
    private readonly ReverseTaskDbContext _context;
    private readonly IMapper _mapper;

    public ConcentrationService(ReverseTaskDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public double CalculateCriterion(List<ConcentrationRequest> concentrations)
    {
        double adequacyCriterion = 0;
        foreach (var concentration in concentrations)
        {
            adequacyCriterion += Math.Pow(concentration.C1A - concentration.C2A, 2) +
                                 Math.Pow(concentration.C1C - concentration.C2C, 2);
        }

        return adequacyCriterion;
    }

    public async Task Save(DataRequest dataRequest)
    {
        var dbData = _mapper.Map<Data>(dataRequest);
        dbData.AdequacyCriterion = CalculateCriterion(dataRequest.Concentrations);

        await _context.Datas.AddAsync(dbData);
        await _context.SaveChangesAsync();
    }
}