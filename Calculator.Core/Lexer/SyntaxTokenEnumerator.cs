using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Core.Lexer
{
    public ref struct SyntaxTokenEnumerator
    {
        private readonly ReadOnlySpan<char> _input;
        private int _index;
        private bool _endOfFile = false;
        public SyntaxToken Current { get; private set; }

        public SyntaxTokenEnumerator(string input)
        {
            _input = input;
            _index = 0;
        }

        public bool MoveNext()
        {
            for (; _index < _input.Length; _index++)
            {
                switch (_input[_index])
                {
                    case '+':
                        Current = new SyntaxToken(SyntaxTokenKind.Plus, _index, _input.Slice(_index, 1));
                        _index++;
                        return true;
                    case '-':
                        Current = new SyntaxToken(SyntaxTokenKind.Minus, _index, _input.Slice(_index, 1));
                        _index++;
                        return true;
                    case '/':
                        Current = new SyntaxToken(SyntaxTokenKind.Slash, _index, _input.Slice(_index, 1));
                        _index++;
                        return true;
                    case '*':
                        Current = new SyntaxToken(SyntaxTokenKind.Star, _index, _input.Slice(_index, 1));
                        _index++;
                        return true;
                    case '^':
                        Current = new SyntaxToken(SyntaxTokenKind.Hat, _index, _input.Slice(_index, 1));
                        _index++;
                        return true;
                    case '(':
                        Current = new SyntaxToken(SyntaxTokenKind.OpenParenthesis, _index, _input.Slice(_index, 1));
                        _index++;
                        return true;
                    case ')':
                        Current = new SyntaxToken(SyntaxTokenKind.CloseParenthesis, _index, _input.Slice(_index, 1));
                        _index++;
                        return true;
                    case var d when Char.IsDigit(d): //match numbers
                    {
                        var str = ReadChars(c => Char.IsDigit(c) || c == '.');
                        Current = new SyntaxToken(SyntaxTokenKind.Number, _index, str);
                        _index += str.Length;
                        return true;
                    }
                    case var l when Char.IsLetter(l): //match identifiers
                        {
                        var str = ReadChars(Char.IsLetterOrDigit);
                        Current = new SyntaxToken(SyntaxTokenKind.Identifier, _index, str);
                        _index += str.Length;
                        return true;
                    }
                    case var w when Char.IsWhiteSpace(w)://skipping white spaces
                        continue;
                    default:
                        Current = new SyntaxToken(SyntaxTokenKind.Unknown, _index, _input.Slice(_index, 1));
                        _index++;
                        return true;
                }
            }

            if (!_endOfFile)
            {
                Current = new SyntaxToken(SyntaxTokenKind.EndOfFile, _index, String.Empty);
                _endOfFile = true;
                return true;
            }
            return false;
        }

        private ReadOnlySpan<char> ReadChars(Func<char, bool> func)
        {
            var count = 0;
            for (var i = 0; _index + i < _input.Length && func(_input[_index + i]); i++)
            {
                count++;
            }

            return _input.Slice(_index, count);
        }

        public void Reset()
        {
            _index = 0;
            _endOfFile = false;
        }
        
        public SyntaxToken GetAndMoveNext()
        {
            var current = Current;
            MoveNext();
            return current;
        }

        public void Dispose()
        {
        }
    }
}