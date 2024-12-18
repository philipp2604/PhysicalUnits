using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test.SI.Base;

public class Mass_Class_UnitTests
{
    [Fact]
    public void GetValue_ReturnsCorrectValue()
    {
        var mass = new Mass(100, Mass.Units.Gram);
        var result = mass.GetValue();

        Assert.Equal(100, result);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromGramsInPounds()
    {
        var mass = new Mass(453.592m, Mass.Units.Gram);
        var result = mass.GetValueInUnit(Mass.Units.Pound);

        Assert.Equal(1, result);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromPoundsInGrams()
    {
        var mass = new Mass(1, Mass.Units.Pound);
        var result = mass.GetValueInUnit(Mass.Units.Gram);

        Assert.Equal(453.592m, result);
    }

    [Fact]
    public void SetValueInUnit_SetsValueCorrectly()
    {
        var mass = new Mass(100, Mass.Units.Gram);
        mass.SetValueInUnit(1, Mass.Units.Pound);

        Assert.Equal(1, mass.GetValue());
    }

    [Fact]
    public void PrintUnit_PrintsCorrectUnit()
    {
        var mass = new Mass(100, Mass.Units.Gram);
        var result = mass.PrintUnit();

        Assert.Equal("Grams", result);
    }

    [Fact]
    public void PrintUnitAbbreviation_PrintsCorrectAbbreviation()
    {
        var mass = new Mass(100, Mass.Units.Gram);
        var result = mass.PrintUnitAbbreviation();

        Assert.Equal("g", result);
    }
}