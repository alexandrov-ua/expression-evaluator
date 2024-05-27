using System.Collections.Generic;
using Calculator.Core.Parser;

namespace Calculator.Core.Evaluator
{
    public readonly struct EvaluatorResult
    {
        public bool IsSuccessful { get; }
        public double Result { get; }
        public IReadOnlyCollection<DiagnosticsEntry> Diagnostics { get; }

        public EvaluatorResult(bool isSuccessful, double result, IReadOnlyCollection<DiagnosticsEntry> diagnostics)
        {
            IsSuccessful = isSuccessful;
            Result = result;
            Diagnostics = diagnostics;
        }
    }
}