using Calculator.Core.FirstImplementation.Evaluator;

namespace Calculator.Core.FirstImplementation.SyntaxThree
{
    public abstract class SyntaxNode
    {
        internal abstract double Accept(SyntaxThreeVisitor visitor);
    }
}