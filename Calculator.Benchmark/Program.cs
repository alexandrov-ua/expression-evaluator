using BenchmarkDotNet.Running;
using Calculator.Benchmark;

//BenchmarkRunner.Run<DoubleTests>();
BenchmarkRunner.Run<ExpressionEvaluatorBenchmark>();
//BenchmarkRunner.Run<SyntaxTokenEnumeratorTest>();