using Calculator.Core.FirstImplementation.Evaluator;


namespace Calculator.Repl
{
    public static class EvaluatorFactory
    {
        public static IStringEvaluator Create()
        {
            return new StringEvaluator();
        }
    }
}