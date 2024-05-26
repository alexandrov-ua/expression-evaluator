using System;
using System.CodeDom;
using System.Linq;
using Calculator.Core.SyntaxThree;
using Calculator.Core.Lexer;
using Calculator.Core.Parser;

namespace Calculator.Core.Evaluator
{
    public class StringEvaluator : IStringEvaluator
    {
        public EvaluatorResult Evaluate(string input)
        {
            var parser = new SyntaxTokenParser(new SyntaxTokenEnumerator(input));
            var parserResult = parser.Parse();
            if (!parserResult.IsSuccessful)
            {
                return new EvaluatorResult(false, Double.NaN, parserResult.Diagnostics.ToArray());
            }
            var syntaxThreeVisitor = new SyntaxThreeVisitor();
            var result = parserResult.Root.Accept(syntaxThreeVisitor);
            if (syntaxThreeVisitor.Diagnostics.Any())
            {
                return new EvaluatorResult(false, Double.NaN, parserResult.Diagnostics.ToArray());
            }

            return new EvaluatorResult(true, result, parserResult.Diagnostics.Concat(syntaxThreeVisitor.Diagnostics).ToArray());
        }
    }
}