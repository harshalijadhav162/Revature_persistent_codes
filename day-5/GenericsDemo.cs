public class Demo
{
    public static void Swap<T>(ref T a, ref T b) where T : class
    {
        T temp = a;
        a = b;
        b = temp;
    }
        // public float Add(float a, float b)
    // {
    //     float sum = a + b;
    //     return sum;
    // }
    // public string Add(string a, string b)
    // {
    //     string sum = a + b;
    //     return sum;
    // }
}