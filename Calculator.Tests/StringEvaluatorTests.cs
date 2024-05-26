using Calculator.Core.Evaluator;
using Calculator.Core.Lexer;
using Calculator.Core.Parser;
using FluentAssertions;
using Xunit;

namespace Calculator.Tests
{
    public class StringEvaluatorTests
    {
        private static double EvaluateSuccess(string input)
        {
            var evaluator = new StringEvaluator();
            var result =  evaluator.Evaluate(input);
            result.IsSuccessful.Should().BeTrue();
            return result.Result;
        }

        [Fact]
        public void SyntaxThreeEvaluator_ShouldEvaluate_BinaryOperators_AccordingToPrecedence()
        {
            var result = EvaluateSuccess("2+3*4");
            result.Should().Be(14);
        }

        [Fact]
        public void SyntaxThreeEvaluator_ShouldEvaluate_BinaryOperators_AccordingToPrecedence2()
        {
            var result = EvaluateSuccess("2*3+4");
            result.Should().Be(10);
        }

        [Fact]
        public void SyntaxThreeEvaluator_ShouldEvaluate_UnaryOperators()
        {
            var result = EvaluateSuccess("2*-4");
            result.Should().Be(-8);
        }

        [Fact]
        public void SyntaxThreeEvaluator_ShouldEvaluate_UnaryOperators2()
        {
            var result = EvaluateSuccess("-2*4");
            result.Should().Be(-8);
        }

        [Fact]
        public void SyntaxThreeEvaluator_ShouldEvaluate_Parenthesis()
        {
            var result = EvaluateSuccess("(2+3)*4");
            result.Should().Be(20);
        }

        [Fact]
        public void SyntaxThreeEvaluator_ShouldEvaluate_AndReturnDoubleResult()
        {
            var result = EvaluateSuccess("3/2");
            result.Should().Be(1.5);
        }

        [Fact]
        public void SyntaxThreeEvaluator_ShouldEvaluate_Doubles()
        {
            var result = EvaluateSuccess("3.2/2.0");
            result.Should().Be(1.6);
        }

        [Fact]
        public void SyntaxThreeEvaluator_ShouldEvaluate_Power()
        {
            var result = EvaluateSuccess("2*3^4");
            result.Should().Be(162);
        }

        [Fact]
        public void SyntaxThreeEvaluator_ShouldEvaluate_Power2()
        {
            var result = EvaluateSuccess("1+2^3*4+5");
            result.Should().Be(38);
        }
        
        [Fact]
        public void Stress()
        {
            var result = EvaluateSuccess("1+2+3+4+5+6+7+8+9+10+11+12+13+14+15+16+17+18+19+20+21+22+23+24+25+26+27+28+29+30+31+32+33+34+35+36+37+38+39+40+41+42+43+44+45+46+47+48+49+50+51+52+53+54+55+56+57+58+59+60+61+62+63+64+65+66+67+68+69+70+71+72+73+74+75+76+77+78+79+80+81+82+83+84+85+86+87+88+89+90+91+92+93+94+95+96+97+98+99+100");
            result.Should().Be(5050);
        }
        
        [Fact]
        public void SyntaxThreeEvaluator_ShouldEvaluate_Dot()
        {
            var result = EvaluateSuccess("1000.5+0.5");
            result.Should().Be(1001);
        }
    }
}