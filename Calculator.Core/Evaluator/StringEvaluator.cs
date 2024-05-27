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
                return new EvaluatorResult(false, Double.NaN, parserResult.Diagnostics);
            }
            var syntaxThreeVisitor = new SyntaxThreeVisitor();
            var result = parserResult.Root.Accept(syntaxThreeVisitor);
            if (syntaxThreeVisitor.Diagnostics.Any())
            {
                return new EvaluatorResult(false, Double.NaN, parserResult.Diagnostics);
            }

            return new EvaluatorResult(true, result, new DiagnosticsEntry[0]);
        }
    }
}