namespace Assignment2.Tests;

public class ExtensionsTests
{

    [Fact]
    public void word_count_returns_5()
    {
        string str = "der står et par ord, men gad vide hvor mange";

        int wordCount = str.WordCount();

        Assert.Equal(10, wordCount);
    }

    [Fact]
    public void uri_secure()
    {
        Uri addr = new Uri("https://google.com");

        bool isSecure = addr.IsSecure();

        Assert.True(isSecure);
    }

    [Fact]
    public void uri_not_secure()
    {
        Uri addr = new Uri("http://google.com");

        bool isSecure = addr.IsSecure();

        Assert.False(isSecure);
    }

}
