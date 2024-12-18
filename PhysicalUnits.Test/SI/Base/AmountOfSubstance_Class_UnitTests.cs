using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test.SI.Base;

public class AmountOfSubstance_Class_UnitTests
{
    [Fact]
    public void GetValue_ReturnsCorrectValue()
    {
        var amount = new AmountOfSubstance(100);
        var result = amount.GetValue();

        Assert.Equal(100, result);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValue()
    {
        var amount = new AmountOfSubstance(100);
        var result = amount.GetValueInUnit(AmountOfSubstance.Units.Mole);

        Assert.Equal(100, result);
    }

    [Fact]
    public void SetValueInUnit_SetsValueCorrectly()
    {
        var amount = new AmountOfSubstance(100);
        amount.SetValueInUnit(1, AmountOfSubstance.Units.Mole);

        Assert.Equal(1, amount.GetValue());
    }

    [Fact]
    public void PrintUnit_PrintsCorrectUnit()
    {
        var amount = new AmountOfSubstance(100);
        var result = amount.PrintUnit();

        Assert.Equal("Moles", result);
    }

    [Fact]
    public void PrintUnitAbbreviation_PrintsCorrectAbbreviation()
    {
        var amount = new AmountOfSubstance(100);
        var result = amount.PrintUnitAbbreviation();

        Assert.Equal("mol", result);
    }
}