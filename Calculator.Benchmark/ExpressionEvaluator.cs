using BenchmarkDotNet.Attributes;
using Calculator.Core.FirstImplementation.Evaluator;
using NewImplementation = Calculator.Core.Evaluator;

namespace Calculator.Benchmark;

[MemoryDiagnoser]
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
        "11+2+3+4+5+6+7+8+9+1+2+3+4+5+6+7+8+9+12+13+14+15+16+176+8768",
        "11+2+3+4+5+6+7+8+9+1+2+3+4+5+6+7+8+9+12+13+14+15+16+176+8768qwe",
        "1+2+3+4+5+6+7+8+9+10+11+12+13+14+15+16+17+18+19+20+21+22+23+24+25+26+27+28+29+30+31+32+33+34+35+36+37+38+39+40+41+42+43+44+45+46+47+48+49+50+51+52+53+54+55+56+57+58+59+60+61+62+63+64+65+66+67+68+69+70+71+72+73+74+75+76+77+78+79+80+81+82+83+84+85+86+87+88+89+90+91+92+93+94+95+96+97+98+99+100"
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