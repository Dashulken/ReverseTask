namespace ReverseTask.Models;

public class Concentration
{
    public int Id { get; set; }
    public double C1A { get; set; }
    public double C2A { get; set; }
    public double C1C { get; set; }
    public double C2C { get; set; }

    public int DataId { get; set; }
    public Data Data { get; set; }
}