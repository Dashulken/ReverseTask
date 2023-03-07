using Microsoft.AspNetCore.Mvc;
using ReverseTask.Requests;
using ReverseTask.Services;

namespace ReverseTask.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ConcentrationController : ControllerBase
{
    private readonly ConcentrationService _service;

    public ConcentrationController(ConcentrationService service)
    {
        _service = service;
    }

    [HttpPost]
    public double CalculateCriterion(List<ConcentrationRequest> concentrations)
    {
        return _service.CalculateCriterion(concentrations);
    }

    [HttpPost]
    public async Task Save(DataRequest data)
    {
        await _service.Save(data);
    }
}