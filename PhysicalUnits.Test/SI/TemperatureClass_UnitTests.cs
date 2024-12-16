using PhysicalUnits.Lib;
using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test.SI;

public class TemperatureClass_UnitTests
{
    [Fact]
    public void Temperature_InitialValueInBaseUnit_ShouldBeCorrect()
    {
        //Arrange
        var temperature = new Temperature(200, Unit.Prefix.Milli);

        //Act
        var valueInBaseUnit = temperature.GetValue(Unit.Prefix.None);

        //Assert
        Assert.Equal(0.200M, valueInBaseUnit);
    }

    [Fact]
    public void Temperature_SetValue_ShouldUpdateValueCorrectly()
    {
        //Arrange
        var temperature = new Temperature(200, Unit.Prefix.Milli);

        //Act
        temperature.SetValue(500, Unit.Prefix.Kilo);
        var valueInBaseUnit = temperature.GetValue(Unit.Prefix.None);

        //Assert
        Assert.Equal(500000.0M, valueInBaseUnit);
    }

    [Fact]
    public void Temperature_GetValue_ShouldReturnCorrectValue()
    {
        //Arrange
        var temperature = new Temperature(200, Unit.Prefix.Milli);

        //Act
        var value = temperature.GetValue(Unit.Prefix.Milli);

        //Assert
        Assert.Equal(200.0M, value);
    }

    [Fact]
    public void Temperature_GetValueWithDifferentPrefix_ShouldReturnConvertedValue()
    {
        //Arrange
        var temperature = new Temperature(200, Unit.Prefix.Milli);

        //Act
        var value = temperature.GetValue(Unit.Prefix.Micro);

        //Assert
        Assert.Equal(200000, value);
    }

    [Fact]
    public void Temperature_GetName_ShouldReturnCorrectName()
    {
        //Arrange
        var temperature = new Temperature(200, Unit.Prefix.Milli);

        //Act
        var name = temperature.GetName();

        //Assert
        Assert.Equal("MilliKelvins", name);
    }

    [Fact]
    public void Temperature_GetAbbreviation_ShouldReturnCorrectName()
    {
        //Arrange
        var temperature = new Temperature(200, Unit.Prefix.Milli);

        //Act
        var abbreviation = temperature.GetAbbreviation();

        //Assert
        Assert.Equal("mK", abbreviation);
    }

    [Fact]
    public void Temperature_GetValueWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Arrange
        var temperature = new Temperature(200, Unit.Prefix.Milli);

        //Assert
        Assert.Throws<ArgumentException>(() => temperature.GetValue((Unit.Prefix)(-1)));
    }

    [Fact]
    public void Temperature_ConstructorWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var temperature = new Temperature(200, (Unit.Prefix)(-1));
        }
        );
    }

    [Fact]
    public void Temperature_SetValueWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Arrange
        var temperature = new Temperature(200, Unit.Prefix.Milli);

        //Assert
        Assert.Throws<ArgumentException>(() => temperature.SetValue(200, (Unit.Prefix)(-1)));
    }
}