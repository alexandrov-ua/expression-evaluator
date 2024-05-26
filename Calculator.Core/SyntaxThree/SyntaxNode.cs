using Calculator.Core.Evaluator;

namespace Calculator.Core.SyntaxThree
{
    public abstract class SyntaxNode
    {
        internal abstract double Accept(SyntaxThreeVisitor visitor);
    }
}