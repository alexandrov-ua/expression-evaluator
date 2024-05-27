using System;
using System.Diagnostics.CodeAnalysis;

namespace Calculator.Core;

public static class MyDoubleParser
{
    /// <summary>
    /// Reimplementation of double.Parse
    /// It ignores sign, exponents, thousands delimiters
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static double Parse(ReadOnlySpan<char> input)
    {
        long integerPart = 0;
        int delimiter = -1;
        for (var i = 0; input.Length > i; i++)
        {
            if (input[i] != '.' && (input[i] < '0' || input[i] > '9'))
                throw new Exception();
            if (input[i] == '.')
            {
                delimiter = i + 1;
                continue;
            }
            integerPart = integerPart * 10 + (input[i] - '0');
        }

        if(delimiter > 0)
            return integerPart / Math.Pow(10, input.Length - delimiter);
        return Convert.ToDouble(integerPart);
    }
}