namespace PhysicalUnits.Lib.SI.Base;

public class ElectricalCurrent(decimal value, PhysicalQuantity.Prefix prefix = PhysicalQuantity.Prefix.None) : PhysicalQuantity(value, Units.Ampere, prefix)
{
    public enum Units
    {
        Ampere
    }

    public override decimal GetValue(Prefix? targetPrefix = Prefix.None)
    {
        targetPrefix ??= CurrentPrefix;
        return _value / GetPrefixMultiplier((Prefix)targetPrefix);
    }

    public override decimal GetValueInUnit(Enum targetUnit, Prefix? targetPrefix = Prefix.None)
    {
        targetPrefix ??= CurrentPrefix;
        return GetValue(targetPrefix);
    }

    public override string PrintUnit()
    {
        return CurrentPrefix == Prefix.None ? Unit.ToString() + "s" : CurrentPrefix.ToString() + Unit.ToString().ToLower() + "s";
    }

    public override string PrintUnitAbbreviation()
    {
        var prefixAbbreviation = GetPrefixAbbreviation(CurrentPrefix);

        return Unit switch
        {
            Units.Ampere => prefixAbbreviation + "A",
            _ => throw new ArgumentOutOfRangeException(nameof(Unit), Unit, null)
        };
    }
}