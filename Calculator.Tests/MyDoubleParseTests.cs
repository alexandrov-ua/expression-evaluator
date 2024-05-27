using System;
using System.Globalization;
using Calculator.Core;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Calculator.Tests;

public class MyDoubleParseTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public MyDoubleParseTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("12")]
    [InlineData("2345")]
    [InlineData("3453463646")]
    [InlineData("1.5")]
    [InlineData("123.2435")]
    [InlineData("1234567.8901")]
    [InlineData("0.5")]
    public void Positive(string p)
    {
        MyDoubleParser.Parse(p).Should().Be(double.Parse(p, CultureInfo.InvariantCulture));
    }

    [Fact]
    public void EmptyString()
    {
        MyDoubleParser.Parse("").Should().Be(0);
    }

    [Theory]
    [InlineData("/")]
    [InlineData(":")]
    [InlineData("asdf")]
    [InlineData("-1.0")]
    [InlineData("1,000.0")]
    [InlineData("5E-324")]
    [InlineData("1.7976931348623157E+308")]
    public void Negative(string p)
    {
        Action func = () => MyDoubleParser.Parse(p);

        func.Should().Throw<Exception>();

    }
}