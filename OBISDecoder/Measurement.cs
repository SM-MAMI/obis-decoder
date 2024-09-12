namespace OBISDecoder;

public class Measurement
{
    public string Topic { get; set; }
    public DateTime Time { get; set; }
    public MeasurementData Message { get; set; }
    
    public override string ToString()
    {
        return $"Topic: {Topic}\n" +
               $"Time: {Time}\n" +
               $"{Message}";
    }
}