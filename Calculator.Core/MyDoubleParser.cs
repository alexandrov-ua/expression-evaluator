using System;

namespace Calculator.Core;

public static class MyDoubleParser
{
    public static double Parse(ReadOnlySpan<char> input)
    {
        long integerPart = 0;
        int delimiter = -1;
        for (var i = 0; input.Length > i; i++)
        {
            if (input[i] == '.')
            {
                delimiter = i + 1;
                continue;
            }
            integerPart = integerPart * 10 + (input[i] - 48);
        }

        if(delimiter > 0)
            return integerPart / Math.Pow(10, input.Length - delimiter);
        return Convert.ToDouble(integerPart);
    }
}