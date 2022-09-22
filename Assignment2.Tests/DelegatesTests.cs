namespace Assignment2.Tests;

public class DelegatesTests
{
    [Fact]
    public void StringReverse()
    {
        string str = "this is a string";

        Func<string, string> reverseFunc = (a) => string.Concat(a.Reverse());

        Assert.Equal("gnirts a si siht", reverseFunc(str));
    }

    [Fact]
    public void DecimalProduct()
    {
        decimal d1 = 0.1m, d2 = 0.2m;

        Func<decimal, decimal, decimal> decimalProduct = (a, b) => a * b;

        Assert.Equal(0.02m, decimalProduct(d1, d2));
    }

    Func<string, int, bool> isEqual = (str, n) => int.Parse(str) == n;

    [Fact]
    public void Equal_true_test()
    {
        string str = "0042";
        int n = 42;

        Assert.True(isEqual(str, n));
    }

    [Fact]
    public void Equal_false_test()
    {
        string str = "0042";
        int n = 43;

        Func<string, int, bool> isEqual = (str, n) => int.Parse(str) == n;

        Assert.False(isEqual(str, n));
    }
}
