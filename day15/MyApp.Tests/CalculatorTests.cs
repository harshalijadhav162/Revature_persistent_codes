using Xunit;
using MyApp;

public class CalculatorTests
{
    [Theory]
    [InlineData(10, 5, 15)]
    [InlineData(2, 3, 5)]
    [InlineData(-1, 1, 0)]
    public void Add_ShouldReturnCorrectSum(int a, int b, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Add(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 5, 5)]
    [InlineData(5, 3, 2)]
    [InlineData(0, 1, -1)]
    public void Subtract_ShouldReturnCorrectResult(int a, int b, int expected)
    {
        var calculator = new Calculator();
        var result = calculator.Subtract(a, b);
        Assert.Equal(expected, result);
    }
}