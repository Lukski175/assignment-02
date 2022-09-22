namespace Assignment2;

public static class Extensions
{
    public static int WordCount(this string str)
    {
        return str.Split(new char[] { ' ', '.', ',', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static bool IsSecure(this Uri uri)
    {
        return uri.Scheme == Uri.UriSchemeHttps;
    }
}
