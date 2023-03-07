namespace ReverseTask.Requests;

public class DataRequest
{
    public double StopCriterion { get; set; }
    public List<ConcentrationRequest> Concentrations { get; set; } = null!;
}