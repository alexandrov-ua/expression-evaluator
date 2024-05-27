using System.Collections.Generic;
using Calculator.Core.SyntaxThree;

namespace Calculator.Core.Parser
{
    public readonly struct ParserResult
    {
        public ParserResult(bool isSuccessful, SyntaxNode root, IReadOnlyCollection<DiagnosticsEntry> diagnostics)
        {
            IsSuccessful = isSuccessful;
            Root = root;
            Diagnostics = diagnostics;
        }

        public bool IsSuccessful { get; }
        public SyntaxNode Root { get; }
        public IReadOnlyCollection<DiagnosticsEntry> Diagnostics { get; }
    }
}