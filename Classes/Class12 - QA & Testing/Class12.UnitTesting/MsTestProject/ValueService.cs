namespace MsTestProject;

public class ValueService
{
    public int? Sum(int num1, int num2)
    {
        var result = num1 + num2;
        if (num1 < 0 && num2 < 0 && result < 0)
        {
            return null;
        }
        return result;
    }

    public bool IsFirstLarger(int num1, int num2)
    {
        return num1 > num2;
    }

    public string GetDigitName(int digit)
    {
        var digitNames = new List<string> { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        return digitNames[digit];
    }


}

[TestClass]
public class ValueTests
{
    private ValueService _service;

    public ValueTests(ValueService service)
    {
        _service = service;
    }

    [TestMethod]
    public void Sum_PositiveIntegers_ResultNumber()
    {
        // Arange
        var num1 = 5;
        var num2 = 5;
        var expectedResult = 10;
        // Act
        var result = _service.Sum(num1, num2);
        // Assert 
        Assert.AreEqual(expectedResult, result);

    }

    [TestMethod]
    public void GetDigitName_NotValidDigit()
    {
        // Arange
        var digit = 10;
        // Act & Assert
        Assert.ThrowsException<IndexOutOfRangeException>((() => _service.GetDigitName(digit)));
    }
}
