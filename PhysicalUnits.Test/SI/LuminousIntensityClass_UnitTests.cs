using PhysicalUnits.Lib;
using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test.SI;

public class LuminousIntensityClass_UnitTests
{
    [Fact]
    public void LuminousIntensity_InitialValueInBaseUnit_ShouldBeCorrect()
    {
        //Arrange
        var intensity = new LuminousIntensity(200, Unit.Prefix.Milli);

        //Act
        var valueInBaseUnit = intensity.GetValue(Unit.Prefix.None);

        //Assert
        Assert.Equal(0.200M, valueInBaseUnit);
    }

    [Fact]
    public void LuminousIntensity_SetValue_ShouldUpdateValueCorrectly()
    {
        //Arrange
        var intensity = new LuminousIntensity(200, Unit.Prefix.Milli);

        //Act
        intensity.SetValue(500, Unit.Prefix.Kilo);
        var valueInBaseUnit = intensity.GetValue(Unit.Prefix.None);

        //Assert
        Assert.Equal(500000.0M, valueInBaseUnit);
    }

    [Fact]
    public void LuminousIntensity_GetValue_ShouldReturnCorrectValue()
    {
        //Arrange
        var intensity = new LuminousIntensity(200, Unit.Prefix.Milli);

        //Act
        var value = intensity.GetValue(Unit.Prefix.Milli);

        //Assert
        Assert.Equal(200.0M, value);
    }

    [Fact]
    public void LuminousIntensity_GetValueWithDifferentPrefix_ShouldReturnConvertedValue()
    {
        //Arrange
        var intensity = new LuminousIntensity(200, Unit.Prefix.Milli);

        //Act
        var value = intensity.GetValue(Unit.Prefix.Micro);

        //Assert
        Assert.Equal(200000, value);
    }

    [Fact]
    public void LuminousIntensity_GetName_ShouldReturnCorrectName()
    {
        //Arrange
        var intensity = new LuminousIntensity(200, Unit.Prefix.Milli);

        //Act
        var name = intensity.GetName();

        //Assert
        Assert.Equal("MilliCandelas", name);
    }

    [Fact]
    public void LuminousIntensity_GetAbbreviation_ShouldReturnCorrectName()
    {
        //Arrange
        var intensity = new LuminousIntensity(200, Unit.Prefix.Milli);

        //Act
        var abbreviation = intensity.GetAbbreviation();

        //Assert
        Assert.Equal("mcd", abbreviation);
    }

    [Fact]
    public void LuminousIntensity_GetValueWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Arrange
        var intensity = new LuminousIntensity(200, Unit.Prefix.Milli);

        //Assert
        Assert.Throws<ArgumentException>(() => intensity.GetValue((Unit.Prefix)(-1)));
    }

    [Fact]
    public void LuminousIntensity_ConstructorWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var intensity = new LuminousIntensity(200, (Unit.Prefix)(-1));
        }
        );
    }

    [Fact]
    public void LuminousIntensity_SetValueWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Arrange
        var intensity = new LuminousIntensity(200, Unit.Prefix.Milli);

        //Assert
        Assert.Throws<ArgumentException>(() => intensity.SetValue(200, (Unit.Prefix)(-1)));
    }
}