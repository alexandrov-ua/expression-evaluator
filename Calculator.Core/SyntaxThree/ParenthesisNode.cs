using Calculator.Core.Evaluator;

namespace Calculator.Core.SyntaxThree
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