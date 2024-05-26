﻿using Calculator.Core.FirstImplementation.Evaluator;

namespace Calculator.Core.FirstImplementation.SyntaxThree
{
    public class PowerBinaryNode : BinaryOperationNode
    {
        public PowerBinaryNode(SyntaxNode left, SyntaxNode right) : base(left, right)
        {
        }

        internal override double Accept(SyntaxThreeVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}