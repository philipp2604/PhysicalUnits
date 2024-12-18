using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test.SI.Base;

public class ElectricalCurrent_Class_UnitTests
{
    [Fact]
    public void GetValue_ReturnsCorrectValue()
    {
        var current = new ElectricalCurrent(100);
        var result = current.GetValue();

        Assert.Equal(100, result);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValue()
    {
        var current = new ElectricalCurrent(100);
        var result = current.GetValueInUnit(ElectricalCurrent.Units.Ampere);

        Assert.Equal(100, result);
    }

    [Fact]
    public void SetValueInUnit_SetsValueCorrectly()
    {
        var current = new ElectricalCurrent(100);
        current.SetValueInUnit(1, ElectricalCurrent.Units.Ampere);

        Assert.Equal(1, current.GetValue());
    }

    [Fact]
    public void PrintUnit_PrintsCorrectUnit()
    {
        var current = new ElectricalCurrent(100);
        var result = current.PrintUnit();

        Assert.Equal("Amperes", result);
    }

    [Fact]
    public void PrintUnitAbbreviation_PrintsCorrectAbbreviation()
    {
        var current = new ElectricalCurrent(100);
        var result = current.PrintUnitAbbreviation();

        Assert.Equal("A", result);
    }
}