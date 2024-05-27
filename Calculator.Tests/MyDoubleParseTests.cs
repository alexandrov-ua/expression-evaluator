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
    
    
    [Fact]
    public void Foo()
    {
        _testOutputHelper.WriteLine(((byte)'0').ToString());
        _testOutputHelper.WriteLine(((byte)'1').ToString());
        _testOutputHelper.WriteLine(((byte)'9').ToString());
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
    public void Bar(string p)
    {
        MyDoubleParser.Parse(p).Should().Be(double.Parse(p, CultureInfo.InvariantCulture));
    }

    [Fact]
    public void Qux()
    {
        _testOutputHelper.WriteLine((0.0/10).ToString());
    }
}