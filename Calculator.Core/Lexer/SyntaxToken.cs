using System;

namespace Calculator.Core.Lexer
{
    public ref struct SyntaxToken
    {
        public SyntaxTokenKind Kind { get; }
        public int StartIndex { get; }
        public ReadOnlySpan<char> Text { get; }

        public SyntaxToken(SyntaxTokenKind kind, int startIndex, ReadOnlySpan<char> text)
        {
            Kind = kind;
            StartIndex = startIndex;
            Text = text;
        }
    }
}