using System.Globalization;
using BenchmarkDotNet.Attributes;
using Calculator.Core;

namespace Calculator.Benchmark;

public class FloatParseTest
{
    [Params("12345.6789","123456489")]
    public string Input { get; set; }

    [Benchmark(Baseline = true)]
    public double Parse()
    {
        return Double.Parse(Input, CultureInfo.InvariantCulture);
    }
    
    [Benchmark]
    public double ParseTuning()
    {
        return Double.Parse(Input, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
    }
    
    [Benchmark]
    public double MyParse()
    {
        return MyDoubleParser.Parse(Input);
    }
}