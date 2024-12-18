using PhysicalUnits.Lib;
using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test;

public class PhysicalQuantity_Class_UnitTests
{
    private class TestPhysicalQuantity(decimal value, Enum unit, PhysicalQuantity.Prefix prefix = PhysicalQuantity.Prefix.None) : PhysicalQuantity(value, unit, prefix)
    {
        public override decimal GetValue(Prefix? targetPrefix = Prefix.None)
        {
            targetPrefix ??= CurrentPrefix;
            return _value / GetPrefixMultiplier((Prefix)targetPrefix);
        }

        public override decimal GetValueInUnit(Enum targetUnit, Prefix? targetPrefix = Prefix.None)
        {
            throw new NotImplementedException();
        }

        public override string PrintUnit()
        {
            throw new NotImplementedException();
        }

        public override string PrintUnitAbbreviation()
        {
            throw new NotImplementedException();
        }
    }

    [Fact]
    public void SetValue_SetsValueCorrectly()
    {
        var quantity = new TestPhysicalQuantity(100, Mass.Units.Gram);
        quantity.SetValue(200);

        Assert.Equal(200, quantity.GetValue());
    }

    [Fact]
    public void SetValue_WithPrefix_SetsValueCorrectly()
    {
        var quantity = new TestPhysicalQuantity(100, Mass.Units.Gram, PhysicalQuantity.Prefix.Milli);
        quantity.SetValue(200, PhysicalQuantity.Prefix.Kilo);

        Assert.Equal(200000, quantity.GetValue());
    }
}