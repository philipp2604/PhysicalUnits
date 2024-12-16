using PhysicalUnits.Lib;
using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test.SI;

public class LengthClass_UnitTests
{
    [Fact]
    public void Length_InitialValueInBaseUnit_ShouldBeCorrect()
    {
        //Arrange
        var length = new Length(200, Unit.Prefix.Milli);

        //Act
        var valueInBaseUnit = length.GetValue(Unit.Prefix.None);

        //Assert
        Assert.Equal(0.200M, valueInBaseUnit);
    }

    [Fact]
    public void Length_SetValue_ShouldUpdateValueCorrectly()
    {
        //Arrange
        var length = new Length(200, Unit.Prefix.Milli);

        //Act
        length.SetValue(500, Unit.Prefix.Kilo);
        var valueInBaseUnit = length.GetValue(Unit.Prefix.None);

        //Assert
        Assert.Equal(500000.0M, valueInBaseUnit);
    }

    [Fact]
    public void Length_GetValue_ShouldReturnCorrectValue()
    {
        //Arrange
        var length = new Length(200, Unit.Prefix.Milli);

        //Act
        var value = length.GetValue(Unit.Prefix.Milli);

        //Assert
        Assert.Equal(200.0M, value);
    }

    [Fact]
    public void Length_GetValueWithDifferentPrefix_ShouldReturnConvertedValue()
    {
        //Arrange
        var length = new Length(200, Unit.Prefix.Milli);

        //Act
        var value = length.GetValue(Unit.Prefix.Micro);

        //Assert
        Assert.Equal(200000, value);
    }

    [Fact]
    public void Length_GetName_ShouldReturnCorrectName()
    {
        //Arrange
        var length = new Length(200, Unit.Prefix.Milli);

        //Act
        var name = length.GetName();

        //Assert
        Assert.Equal("MilliMeters", name);
    }

    [Fact]
    public void Length_GetAbbreviation_ShouldReturnCorrectName()
    {
        //Arrange
        var length = new Length(200, Unit.Prefix.Milli);

        //Act
        var abbreviation = length.GetAbbreviation();

        //Assert
        Assert.Equal("mm", abbreviation);
    }

    [Fact]
    public void Length_GetValueWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Arrange
        var length = new Length(200, Unit.Prefix.Milli);

        //Assert
        Assert.Throws<ArgumentException>(() => length.GetValue((Unit.Prefix)(-1)));
    }

    [Fact]
    public void Length_ConstructorWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var length = new Length(200, (Unit.Prefix)(-1));
        }
        );
    }

    [Fact]
    public void Length_SetValueWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Arrange
        var length = new Length(200, Unit.Prefix.Milli);

        //Assert
        Assert.Throws<ArgumentException>(() => length.SetValue(200, (Unit.Prefix)(-1)));
    }
}