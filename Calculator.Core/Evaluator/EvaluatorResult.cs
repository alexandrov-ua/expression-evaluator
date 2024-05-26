using Calculator.Core.Parser;

namespace Calculator.Core.Evaluator
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