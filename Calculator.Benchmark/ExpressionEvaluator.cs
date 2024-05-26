using BenchmarkDotNet.Attributes;
using Calculator.Core.FirstImplementation.Evaluator;
using NewImplementation = Calculator.Core.Evaluator;

namespace Calculator.Benchmark;

[MemoryDiagnoser]
[HtmlExporter]
[RPlotExporter]
public class ExpressionEvaluatorBenchmark
{
    private readonly StringEvaluator _evaluator;
    private readonly NewImplementation.StringEvaluator _newEvaluator;

    public ExpressionEvaluatorBenchmark()
    {
        _evaluator = new StringEvaluator();
        _newEvaluator = new NewImplementation.StringEvaluator();
    }

    [Params(
        "1+2^3*4+5",
        "1+2+3+4+5+6+7+8+9+1+2+3+4+5+6+7+8+9+12+13+14+15+16+176+8768",
        "1+2+3+4+5+6+7+8+9+1+2+3+4+5+6+7+8+9+12+13+14+15+16+176+8768qwe"
        )]
    public string Input { get; set; }

    [Benchmark(Baseline = true)]
    public double Evaluate()
    {
        return _evaluator.Evaluate(Input).Result;
    }

    [Benchmark]
    public double EvaluateNew()
    {
        return _newEvaluator.Evaluate(Input).Result;
    }

}