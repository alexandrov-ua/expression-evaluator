using System;
using System.Collections.Generic;
using System.Linq;
using Calculator.Core;
using Calculator.Core.Lexer;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Calculator.Tests
{
    public static class Ext
    {
        public static IEnumerable<(SyntaxTokenKind, string, int)> ToListOfTuple(this SyntaxTokenEnumerator iterator)
        {
            List<(SyntaxTokenKind, string, int)> result = new List<(SyntaxTokenKind, string, int)>();

            while (iterator.MoveNext())
            {
                result.Add(new (iterator.Current.Kind, iterator.Current.Text.ToString(), iterator.Current.StartIndex));
            }

            return result;
        }
    }

    public class SyntaxTokenEnumerableTests
    {
        private readonly ITestOutputHelper _testOutputHelper;


        public SyntaxTokenEnumerableTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Foo()
        {
            _testOutputHelper.WriteLine(string.Join("+", Enumerable.Range(1,100).Select(i=>i.ToString())));
        }

        [Fact]
        public void SyntaxTokenEnumerable_ShouldByAbleToParse_Operations()
        {
            new SyntaxTokenEnumerator(" + -/ *")
                .ToListOfTuple()
                .Should()
                .BeEquivalentTo(new[]
                {
                    (SyntaxTokenKind.Plus, "+", 1),
                    (SyntaxTokenKind.Minus, "-", 3),
                    (SyntaxTokenKind.Slash, "/", 4),
                    (SyntaxTokenKind.Star, "*", 6),
                    (SyntaxTokenKind.EndOfFile, "", 7),
                });
        }

        [Fact]
        public void SyntaxTokenEnumerable_ShouldByAbleToParse_Parenthesis()
        {
            new SyntaxTokenEnumerator("( ) (")
                .ToListOfTuple()
                .Should()
                .BeEquivalentTo(new[]
                {
                    (SyntaxTokenKind.OpenParenthesis, "(", 0),
                    (SyntaxTokenKind.CloseParenthesis, ")", 2),
                    (SyntaxTokenKind.OpenParenthesis, "(", 4),
                    (SyntaxTokenKind.EndOfFile, "", 5),
                });
        }

        [Fact]
        public void SyntaxTokenEnumerable_ShouldByAbleToParse_Numbers()
        {
            new SyntaxTokenEnumerator("12+3.0-7.")
                .ToListOfTuple()
                .Should()
                .BeEquivalentTo(new[]
                {
                    (SyntaxTokenKind.Number, "12", 0),
                    (SyntaxTokenKind.Plus, "+", 2),
                    (SyntaxTokenKind.Number, "3.0", 3),
                    (SyntaxTokenKind.Minus, "-", 6),
                    (SyntaxTokenKind.Number, "7.", 7),
                    (SyntaxTokenKind.EndOfFile, "", 9),
                });
        }

        [Fact]
        public void SyntaxTokenEnumerable_ShouldByAbleToParse_Identifier()
        {
            new SyntaxTokenEnumerator("sin(0.5)")
                .ToListOfTuple()
                .Should()
                .BeEquivalentTo(new[]
                {
                    (SyntaxTokenKind.Identifier, "sin", 0),
                    (SyntaxTokenKind.OpenParenthesis, "(", 3),
                    (SyntaxTokenKind.Number, "0.5", 4),
                    (SyntaxTokenKind.CloseParenthesis, ")", 7),
                    (SyntaxTokenKind.EndOfFile, "", 8),
                });
        }

        [Fact]
        public void SyntaxTokenEnumerable_ShouldByAbleToParse_Identifier2()
        {
            new SyntaxTokenEnumerator("log10(0.5)")
                .ToListOfTuple()
                .Should()
                .BeEquivalentTo(new[]
                {
                    (SyntaxTokenKind.Identifier, "log10", 0),
                    (SyntaxTokenKind.OpenParenthesis, "(", 5),
                    (SyntaxTokenKind.Number, "0.5", 6),
                    (SyntaxTokenKind.CloseParenthesis, ")", 9),
                    (SyntaxTokenKind.EndOfFile, "", 10),
                });
        }

        [Fact]
        public void SyntaxTokenEnumerable_ShouldByAbleToHandle_UnknownTokens()
        {
            new SyntaxTokenEnumerator("!2qwe#")
                .ToListOfTuple()
                .Should()
                .BeEquivalentTo(new[]
                {
                    (SyntaxTokenKind.Unknown, "!", 0),
                    (SyntaxTokenKind.Number, "2", 1),
                    (SyntaxTokenKind.Identifier, "qwe", 2),
                    (SyntaxTokenKind.Unknown, "#", 5),
                    (SyntaxTokenKind.EndOfFile, "", 6),
                });
        }

        [Fact]
        public void SyntaxTokenEnumerable_ShouldByAbleToHandle_EmptyString()
        {
            new SyntaxTokenEnumerator("")
                .ToListOfTuple()
                .Should()
                .BeEquivalentTo(new []
                {
                    (SyntaxTokenKind.EndOfFile, "", 0),
                });
        }

        [Fact]
        public void SyntaxTokenEnumerable_ShouldByAbleToHandle_WhiteSpaces()
        {
            new SyntaxTokenEnumerator(" \t\n")
                .ToListOfTuple()
                .Should()
                .BeEquivalentTo(new[]
                {
                    (SyntaxTokenKind.EndOfFile, "", 3),
                });
        }
    }
}
