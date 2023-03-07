namespace ReverseTask.Models;

public class Data
{
    public int Id { get; set; }
    public double AdequacyCriterion { get; set; }
    public double StopCriterion { get; set; }
    public ICollection<Concentration> Concentrations { get; set; } = null!;
}