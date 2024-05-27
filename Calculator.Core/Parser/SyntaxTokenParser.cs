using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Calculator.Core.Lexer;
using Calculator.Core.SyntaxThree;

namespace Calculator.Core.Parser
{
    public ref struct SyntaxTokenParser
    {
        private SyntaxTokenEnumerator _tokens;
        private readonly DiagnosticsBag _diagnostics = new DiagnosticsBag();
        public SyntaxTokenParser(SyntaxTokenEnumerator tokens)
        {
            _tokens = tokens;
        }

        public ParserResult Parse()
        {
            _tokens.MoveNext();
            var root = ParseBinaryExpression();
            var endOfFile = MatchToken(SyntaxTokenKind.EndOfFile);
            return new ParserResult(!_diagnostics.Any(), root, _diagnostics.ToArray());
        }

        private SyntaxToken MatchToken(SyntaxTokenKind kind)
        {
            if (_tokens.Current.Kind == kind)
            {
                var current = _tokens.Current;
                _tokens.MoveNext();
                return current;
            }
            _diagnostics.ReportError(DiagnosticKind.UnexpectedToken, _tokens.Current.StartIndex, _tokens.Current.Text.Length, kind, _tokens.Current.Kind);
            _tokens.MoveNext();
            return new SyntaxToken(kind, 0, null);
        }

        private SyntaxNode ParseBinaryExpression(int parentPrecedence = 0)
        {
            SyntaxNode left = ParseUnaryOrParenthesisOrValue();
            while (true)
            {
                var precedence = _tokens.Current.Kind.GetBinaryOperationPrecedence();
                if (!_tokens.Current.Kind.IsInTokenGroup(SyntaxTokenGroup.Binary) || precedence <= parentPrecedence)
                    break;
                var op = _tokens.GetAndMoveNext();
                var right = ParseBinaryExpression(precedence);
                left = BinaryOperationNode.Create(left, op, right);
            }

            return left;
        }

        private SyntaxNode ParseUnaryOrParenthesisOrValue()
        {
            switch (_tokens.Current.Kind)
            {
                case var k when k.IsInTokenGroup(SyntaxTokenGroup.Unary):
                    return ParseUnaryExpression();
                case SyntaxTokenKind.OpenParenthesis:
                    return ParseParenthesis();
                default:
                    return ParseNumberLiteral();
            }
        }

        private SyntaxNode ParseUnaryExpression()
        {
         
            var operatorToken = _tokens.GetAndMoveNext();
            var operand = ParseUnaryOrParenthesisOrValue();
            return UnaryOperatorNode.Create(operatorToken, operand);
        }

        private SyntaxNode ParseParenthesis()
        {
            var left = MatchToken(SyntaxTokenKind.OpenParenthesis);
            var expression = ParseBinaryExpression();
            var right = MatchToken(SyntaxTokenKind.CloseParenthesis);
            return new ParenthesisNode(expression);
        }

        private SyntaxNode ParseNumberLiteral()
        {
            var literal = MatchToken(SyntaxTokenKind.Number);
            var value = literal.Text.IsEmpty ? 0.0d : MyDoubleParser.Parse(literal.Text); //double.Parse(literal.Text, CultureInfo.InvariantCulture);
            return new NumberNode(value);
        }
    }
}
