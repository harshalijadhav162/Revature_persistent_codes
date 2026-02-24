AddFunctionShouldReturn30ForInputs10And20();
AddFunctionShouldReturn40ForInputs20And20();
AddFunctionShouldReturn50ForInputs25And25();

void AddFunctionShouldReturn30ForInputs10And20()
{
    var x = 10;
    var y = 20;
    var expectedResult = 30;

    var actualResult = Add(x, y);

    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");

    if (actualResult == expectedResult)
    {
        Console.WriteLine("Test Passed");
    }
    else
    {
        Console.WriteLine("Test Failed");
    }
}

void AddFunctionShouldReturn40ForInputs20And20()
{
    var actualResult = Add(20, 20);
    var expectedResult = 40;

    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");

    if (actualResult == expectedResult)
    {
        Console.WriteLine("Test Passed");
    }
    else
    {
        Console.WriteLine("Test Failed");
    }
}

void AddFunctionShouldReturn50ForInputs25And25()
{
    var actualResult = Add(25, 25);
    var expectedResult = 50;

    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");

    if (actualResult == expectedResult)
    {
        Console.WriteLine("Test Passed");
    }
    else
    {
        Console.WriteLine("Test Failed");
    }
}

int Add(int a, int b)
{
    return a + b;
}