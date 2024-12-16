using PhysicalUnits.Lib;
using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test.SI;

public class TimeClass_UnitTests
{
    [Fact]
    public void Time_InitialValueInBaseUnit_ShouldBeCorrect()
    {
        //Arrange
        var time = new Time(200, Unit.Prefix.Milli);

        //Act
        var valueInBaseUnit = time.GetValue(Unit.Prefix.None);

        //Assert
        Assert.Equal(0.200M, valueInBaseUnit);
    }

    [Fact]
    public void Time_SetValue_ShouldUpdateValueCorrectly()
    {
        //Arrange
        var time = new Time(200, Unit.Prefix.Milli);

        //Act
        time.SetValue(500, Unit.Prefix.Kilo);
        var valueInBaseUnit = time.GetValue(Unit.Prefix.None);

        //Assert
        Assert.Equal(500000.0M, valueInBaseUnit);
    }

    [Fact]
    public void Time_GetValue_ShouldReturnCorrectValue()
    {
        //Arrange
        var time = new Time(200, Unit.Prefix.Milli);

        //Act
        var value = time.GetValue(Unit.Prefix.Milli);

        //Assert
        Assert.Equal(200.0M, value);
    }

    [Fact]
    public void Time_GetValueWithDifferentPrefix_ShouldReturnConvertedValue()
    {
        //Arrange
        var time = new Time(200, Unit.Prefix.Milli);

        //Act
        var value = time.GetValue(Unit.Prefix.Micro);

        //Assert
        Assert.Equal(200000, value);
    }

    [Fact]
    public void Time_GetName_ShouldReturnCorrectName()
    {
        //Arrange
        var time = new Time(200, Unit.Prefix.Milli);

        //Act
        var name = time.GetName();

        //Assert
        Assert.Equal("MilliSeconds", name);
    }

    [Fact]
    public void Time_GetAbbreviation_ShouldReturnCorrectName()
    {
        //Arrange
        var time = new Time(200, Unit.Prefix.Milli);

        //Act
        var abbreviation = time.GetAbbreviation();

        //Assert
        Assert.Equal("ms", abbreviation);
    }

    [Fact]
    public void Time_GetValueWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Arrange
        var time = new Time(200, Unit.Prefix.Milli);

        //Assert
        Assert.Throws<ArgumentException>(() => time.GetValue((Unit.Prefix)(-1)));
    }

    [Fact]
    public void Time_ConstructorWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var time = new Time(200, (Unit.Prefix)(-1));
        }
        );
    }

    [Fact]
    public void Time_SetValueWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Arrange
        var time = new Time(200, Unit.Prefix.Milli);

        //Assert
        Assert.Throws<ArgumentException>(() => time.SetValue(200, (Unit.Prefix)(-1)));
    }
}