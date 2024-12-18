using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test.SI.Base;

public class Temperature_Class_UnitTests
{
    [Fact]
    public void GetValue_ReturnsCorrectValue()
    {
        var temperature = new Temperature(100, Temperature.Units.Celsius);
        var result = temperature.GetValue();

        Assert.Equal(100, result);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromCelsiusInKelvin()
    {
        var temperature = new Temperature(100, Temperature.Units.Celsius);
        var result = temperature.GetValueInUnit(Temperature.Units.Kelvin);

        Assert.Equal(373.15m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromCelsiusInFahrenheit()
    {
        var temperature = new Temperature(100, Temperature.Units.Celsius);
        var result = temperature.GetValueInUnit(Temperature.Units.Fahrenheit);

        Assert.Equal(212, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromKelvinInCelsius()
    {
        var temperature = new Temperature(100, Temperature.Units.Kelvin);
        var result = temperature.GetValueInUnit(Temperature.Units.Celsius);

        Assert.Equal(-173.15m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromKelvinInFahrenheit()
    {
        var temperature = new Temperature(100, Temperature.Units.Kelvin);
        var result = temperature.GetValueInUnit(Temperature.Units.Fahrenheit);

        Assert.Equal(-279.67m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromFahrenheitInCelsius()
    {
        var temperature = new Temperature(100, Temperature.Units.Fahrenheit);
        var result = temperature.GetValueInUnit(Temperature.Units.Celsius);

        Assert.Equal(37.7778m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromFahrenheitInKelvin()
    {
        var temperature = new Temperature(100, Temperature.Units.Fahrenheit);
        var result = temperature.GetValueInUnit(Temperature.Units.Kelvin);

        Assert.Equal(310.9278m, result, 4);
    }

    [Fact]
    public void SetValueInUnit_SetsValueCorrectly()
    {
        var temperature = new Temperature(100, Temperature.Units.Kelvin);
        temperature.SetValueInUnit(1, Temperature.Units.Celsius);

        Assert.Equal(1, temperature.GetValue());
    }

    [Fact]
    public void PrintUnit_PrintsCorrectUnit()
    {
        var temperature = new Temperature(100, Temperature.Units.Celsius);
        var result = temperature.PrintUnit();

        Assert.Equal("Celsius", result);
    }

    [Fact]
    public void PrintUnitAbbreviation_PrintsCorrectAbbreviation()
    {
        var temperature = new Temperature(100, Temperature.Units.Kelvin);
        var result = temperature.PrintUnitAbbreviation();

        Assert.Equal("K", result);
    }
}