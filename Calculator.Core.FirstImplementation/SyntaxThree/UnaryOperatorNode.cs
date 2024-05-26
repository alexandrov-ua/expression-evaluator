using System;
using Calculator.Core.FirstImplementation.Lexer;

namespace Calculator.Core.FirstImplementation.SyntaxThree
{
    public abstract class UnaryOperatorNode : SyntaxNode
    {
        public SyntaxNode Operand { get; }

        public UnaryOperatorNode(SyntaxNode operand)
        {
            Operand = operand;
        }

        public static UnaryOperatorNode Create(SyntaxToken token, SyntaxNode node)
        {
            switch (token.Kind)
            {
                case SyntaxTokenKind.Minus:
                    return new MinusUnaryNode(node);
                case SyntaxTokenKind.Plus:
                    return new PlusUnaryNode(node);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}