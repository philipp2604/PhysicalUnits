using PhysicalUnits.Lib;
using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test.SI;

public class MassClass_UnitTests
{
    [Fact]
    public void Mass_InitialValueInBaseUnit_ShouldBeCorrect()
    {
        //Arrange
        var mass = new Mass(200, Unit.Prefix.Milli);

        //Act
        var valueInBaseUnit = mass.GetValue(Unit.Prefix.None);

        //Assert
        Assert.Equal(0.200M, valueInBaseUnit);
    }

    [Fact]
    public void Mass_SetValue_ShouldUpdateValueCorrectly()
    {
        //Arrange
        var mass = new Mass(200, Unit.Prefix.Milli);

        //Act
        mass.SetValue(500, Unit.Prefix.Kilo);
        var valueInBaseUnit = mass.GetValue(Unit.Prefix.None);

        //Assert
        Assert.Equal(500000.0M, valueInBaseUnit);
    }

    [Fact]
    public void Mass_GetValue_ShouldReturnCorrectValue()
    {
        //Arrange
        var mass = new Mass(200, Unit.Prefix.Milli);

        //Act
        var value = mass.GetValue(Unit.Prefix.Milli);

        //Assert
        Assert.Equal(200.0M, value);
    }

    [Fact]
    public void Mass_GetValueWithDifferentPrefix_ShouldReturnConvertedValue()
    {
        //Arrange
        var mass = new Mass(200, Unit.Prefix.Milli);

        //Act
        var value = mass.GetValue(Unit.Prefix.Micro);

        //Assert
        Assert.Equal(200000, value);
    }

    [Fact]
    public void Mass_GetName_ShouldReturnCorrectName()
    {
        //Arrange
        var mass = new Mass(200, Unit.Prefix.Milli);

        //Act
        var name = mass.GetName();

        //Assert
        Assert.Equal("MilliGrams", name);
    }

    [Fact]
    public void Mass_GetAbbreviation_ShouldReturnCorrectName()
    {
        //Arrange
        var mass = new Mass(200, Unit.Prefix.Milli);

        //Act
        var abbreviation = mass.GetAbbreviation();

        //Assert
        Assert.Equal("mg", abbreviation);
    }

    [Fact]
    public void Mass_GetValueWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Arrange
        var mass = new Mass(200, Unit.Prefix.Milli);

        //Assert
        Assert.Throws<ArgumentException>(() => mass.GetValue((Unit.Prefix)(-1)));
    }

    [Fact]
    public void Mass_ConstructorWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var mass = new Mass(200, (Unit.Prefix)(-1));
        }
        );
    }

    [Fact]
    public void Mass_SetValueWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Arrange
        var mass = new Mass(200, Unit.Prefix.Milli);

        //Assert
        Assert.Throws<ArgumentException>(() => mass.SetValue(200, (Unit.Prefix)(-1)));
    }
}