[TestMethod]
public void Add_ShouldReturn30_When10And20()
{
    var calculator = new Calculator();
    var result = calculator.Add(10, 20);

    Assert.AreEqual(30, result);
}