using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Calculator.Core.Lexer
{
    public enum SyntaxTokenKind
    {
        Plus,
        Minus,
        Star,
        Slash,
        Hat,
        OpenParenthesis,
        CloseParenthesis,
        Number,
        Identifier,
        Unknown,
        EndOfFile
    }

    public enum SyntaxTokenGroup
    {
        Binary,
        Unary,
    }

    public static class SyntaxTokenKindExtensions
    {
        public static int GetBinaryOperationPrecedence(this SyntaxTokenKind kind)
        {
            return kind switch
            {
                SyntaxTokenKind.Plus => 1,
                SyntaxTokenKind.Minus => 1,
                SyntaxTokenKind.Star => 2,
                SyntaxTokenKind.Slash => 2,
                SyntaxTokenKind.Hat => 3,
                _ => 0
            };
        }
        public static bool IsInTokenGroup(this SyntaxTokenKind kind, SyntaxTokenGroup @group)
        {
            return (kind, @group) switch
            {
                (SyntaxTokenKind.Plus, SyntaxTokenGroup.Binary) => true,
                (SyntaxTokenKind.Plus, SyntaxTokenGroup.Unary) => true,
                (SyntaxTokenKind.Minus, SyntaxTokenGroup.Binary) => true,
                (SyntaxTokenKind.Minus, SyntaxTokenGroup.Unary) => true,
                (SyntaxTokenKind.Star, SyntaxTokenGroup.Binary) => true,
                (SyntaxTokenKind.Slash, SyntaxTokenGroup.Binary) => true,
                (SyntaxTokenKind.Hat, SyntaxTokenGroup.Binary) => true,
                (_, _) => false
            };
        }
    }

}