using System.Diagnostics;
using Newtonsoft.Json;

namespace OBISDecoder;

class Program
{
    private static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: OBISDecoder <input-file> <output-file>");
            return;
        }
        
        var stopwatch = Stopwatch.StartNew();
        var inputFilePath = args[0];
        var outputFilePath = args[1];

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"The provided file '{inputFilePath}' could not be found.");
            return;
        }
        
        Console.WriteLine($"Reading from input file: {inputFilePath}");
        var jsonContent = File.ReadAllText(inputFilePath);
        Console.WriteLine("Successfully read input file.");
        
        Console.WriteLine("Decoding JSON content...");
        var measurements = JsonConvert.DeserializeObject<List<Measurement>>(jsonContent);
        
        if (measurements == null)
        {
            Console.WriteLine("Could not decode JSON.");
            return;
        }
        Console.WriteLine($"Decoded {measurements.Count} measurements.");

        Console.WriteLine($"Writing measurements to output file: {outputFilePath}");
        using var writer = new StreamWriter(outputFilePath);
        foreach (var measurement in measurements)
        {
            writer.WriteLine(measurement);
            writer.WriteLine("-----------------------------------------------------");
        }

        stopwatch.Stop();
        var elapsed = stopwatch.Elapsed;
        Console.WriteLine($"Measurements have been written to '{outputFilePath}'.");
        Console.WriteLine($"Total time elapsed: {elapsed.TotalSeconds:F2} seconds.");
    }
}