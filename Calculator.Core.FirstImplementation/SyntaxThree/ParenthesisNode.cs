using Calculator.Core.FirstImplementation.Evaluator;

namespace Calculator.Core.FirstImplementation.SyntaxThree
{
    public class ParenthesisNode : SyntaxNode
    {
        public SyntaxNode Expression { get; }

        public ParenthesisNode(SyntaxNode expression)
        {
            Expression = expression;
        }
        internal override double Accept(SyntaxThreeVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}