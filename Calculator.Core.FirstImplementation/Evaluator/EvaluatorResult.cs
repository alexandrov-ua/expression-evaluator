using Calculator.Core.FirstImplementation.Parser;

namespace Calculator.Core.FirstImplementation.Evaluator
{
    public class EvaluatorResult
    {
        public bool IsSuccessful { get; }
        public double Result { get; }
        public DiagnosticsEntry[] Diagnostics { get; }

        public EvaluatorResult(bool isSuccessful, double result, DiagnosticsEntry[] diagnostics)
        {
            IsSuccessful = isSuccessful;
            Result = result;
            Diagnostics = diagnostics;
        }
    }
}