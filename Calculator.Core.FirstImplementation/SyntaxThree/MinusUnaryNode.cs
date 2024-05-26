using Calculator.Core.FirstImplementation.Evaluator;

namespace Calculator.Core.FirstImplementation.SyntaxThree
{
    public class MinusUnaryNode : UnaryOperatorNode
    {
        public MinusUnaryNode(SyntaxNode operand) : base(operand)
        {
        }

        internal override double Accept(SyntaxThreeVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}