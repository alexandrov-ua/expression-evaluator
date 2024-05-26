﻿using Calculator.Core.Evaluator;

namespace Calculator.Core.SyntaxThree
{
    public class PlusBinaryNode : BinaryOperationNode
    {
        public PlusBinaryNode(SyntaxNode left, SyntaxNode right) : base(left, right)
        {
        }

        internal override double Accept(SyntaxThreeVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}