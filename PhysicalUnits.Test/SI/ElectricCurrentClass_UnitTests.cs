using PhysicalUnits.Lib;
using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test.SI;

public class ElectricCurrentClass_UnitTests
{
    [Fact]
    public void ElectricCurrent_InitialValueInBaseUnit_ShouldBeCorrect()
    {
        //Arrange
        var current = new ElectricCurrent(200, Unit.Prefix.Milli);

        //Act
        var valueInBaseUnit = current.GetValue(Unit.Prefix.None);

        //Assert
        Assert.Equal(0.200M, valueInBaseUnit);
    }

    [Fact]
    public void ElectricCurrent_SetValue_ShouldUpdateValueCorrectly()
    {
        //Arrange
        var current = new ElectricCurrent(200, Unit.Prefix.Milli);

        //Act
        current.SetValue(500, Unit.Prefix.Kilo);
        var valueInBaseUnit = current.GetValue(Unit.Prefix.None);

        //Assert
        Assert.Equal(500000.0M, valueInBaseUnit);
    }

    [Fact]
    public void ElectricCurrent_GetValue_ShouldReturnCorrectValue()
    {
        //Arrange
        var current = new ElectricCurrent(200, Unit.Prefix.Milli);

        //Act
        var value = current.GetValue(Unit.Prefix.Milli);

        //Assert
        Assert.Equal(200.0M, value);
    }

    [Fact]
    public void ElectricCurrent_GetValueWithDifferentPrefix_ShouldReturnConvertedValue()
    {
        //Arrange
        var current = new ElectricCurrent(200, Unit.Prefix.Milli);

        //Act
        var value = current.GetValue(Unit.Prefix.Micro);

        //Assert
        Assert.Equal(200000, value);
    }

    [Fact]
    public void ElectricCurrent_GetName_ShouldReturnCorrectName()
    {
        //Arrange
        var current = new ElectricCurrent(200, Unit.Prefix.Milli);

        //Act
        var name = current.GetName();

        //Assert
        Assert.Equal("MilliAmperes", name);
    }

    [Fact]
    public void ElectricCurrent_GetAbbreviation_ShouldReturnCorrectName()
    {
        //Arrange
        var current = new ElectricCurrent(200, Unit.Prefix.Milli);

        //Act
        var abbreviation = current.GetAbbreviation();

        //Assert
        Assert.Equal("mA", abbreviation);
    }

    [Fact]
    public void ElectricCurrent_GetValueWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Arrange
        var current = new ElectricCurrent(200, Unit.Prefix.Milli);

        //Assert
        Assert.Throws<ArgumentException>(() => current.GetValue((Unit.Prefix)(-1)));
    }

    [Fact]
    public void ElectricCurrent_ConstructorWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var current = new ElectricCurrent(200, (Unit.Prefix)(-1));
        }
        );
    }

    [Fact]
    public void ElectricCurrent_SetValueWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Arrange
        var current = new ElectricCurrent(200, Unit.Prefix.Milli);

        //Assert
        Assert.Throws<ArgumentException>(() => current.SetValue(200, (Unit.Prefix)(-1)));
    }
}