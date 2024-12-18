using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test.SI.Base;

public class LuminousIntensity_Class_UnitTests
{
    [Fact]
    public void GetValue_ReturnsCorrectValue()
    {
        var intensity = new LuminousIntensity(100);
        var result = intensity.GetValue();

        Assert.Equal(100, result);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValue()
    {
        var intensity = new LuminousIntensity(100);
        var result = intensity.GetValueInUnit(LuminousIntensity.Units.Candela);

        Assert.Equal(100, result);
    }

    [Fact]
    public void SetValueInUnit_SetsValueCorrectly()
    {
        var intensity = new LuminousIntensity(100);
        intensity.SetValueInUnit(1, LuminousIntensity.Units.Candela);

        Assert.Equal(1, intensity.GetValue());
    }

    [Fact]
    public void PrintUnit_PrintsCorrectUnit()
    {
        var intensity = new LuminousIntensity(100);
        var result = intensity.PrintUnit();

        Assert.Equal("Candelas", result);
    }

    [Fact]
    public void PrintUnitAbbreviation_PrintsCorrectAbbreviation()
    {
        var intensity = new LuminousIntensity(100);
        var result = intensity.PrintUnitAbbreviation();

        Assert.Equal("cd", result);
    }
}