namespace ExtensionMethodsDemo
{
    public static class StringExtensions
    {
        public static int WordCount(this string str)
        {
            return str.Split(' ').Length;
        }
    }
}
