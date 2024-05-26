using Calculator.Core.FirstImplementation.Evaluator;

namespace Calculator.Core.FirstImplementation.SyntaxThree
{
    public class NumberNode : SyntaxNode
    {
        public NumberNode(double value)
        {
            Value = value;
        }

        public double Value { get; }

        internal override double Accept(SyntaxThreeVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}