namespace PhysicalUnits.Lib.SI.Base;

using System;

public class LuminousIntensity(decimal value, PhysicalQuantity.Prefix prefix = PhysicalQuantity.Prefix.None) : PhysicalQuantity(value, Units.Candela, prefix)
{
    public enum Units
    {
        Candela
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
            Units.Candela => prefixAbbreviation + "cd",
            _ => throw new ArgumentOutOfRangeException(nameof(Unit), Unit, null)
        };
    }
}