﻿using System.Collections.Generic;
using Calculator.Core.SyntaxThree;

namespace Calculator.Core.Parser
{
    public class ParserResult
    {
        public ParserResult(bool isSuccessful, SyntaxNode root, DiagnosticsEntry[] diagnostics)
        {
            IsSuccessful = isSuccessful;
            Root = root;
            Diagnostics = diagnostics;
        }

        public bool IsSuccessful { get; }
        public SyntaxNode Root { get; }
        public DiagnosticsEntry[] Diagnostics { get; }
    }
}