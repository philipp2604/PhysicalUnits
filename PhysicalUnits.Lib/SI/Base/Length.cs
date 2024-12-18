namespace PhysicalUnits.Lib.SI.Base;

public class Length(decimal value, Length.Units unit, PhysicalQuantity.Prefix prefix = PhysicalQuantity.Prefix.None) : PhysicalQuantity(value, unit, prefix)
{
    public enum Units
    {
        Meter,
        Inch,
        Foot,
        Yard,
        Mile
    }

    public override decimal GetValue(Prefix? targetPrefix = Prefix.None)
    {
        targetPrefix ??= CurrentPrefix;
        return _value / GetPrefixMultiplier((Prefix)targetPrefix);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2208:Argumentausnahmen korrekt instanziieren", Justification = "<Ausstehend>")]
    public override decimal GetValueInUnit(Enum targetUnit, Prefix? targetPrefix = Prefix.None)
    {
        targetUnit ??= Unit;
        targetPrefix ??= CurrentPrefix;

        if (targetUnit is not Units)
            throw new ArgumentException("Invalid target unit for Length", nameof(targetUnit));

        var baseValue = Unit switch
        {
            Units.Meter => _value,
            Units.Inch => _value * 0.0254m,
            Units.Foot => _value * 0.3048m,
            Units.Yard => _value * 0.9144m,
            Units.Mile => _value * 1609.344m,
            _ => throw new ArgumentOutOfRangeException(nameof(Unit), Unit, null)
        };

        var targetBaseValue = targetUnit switch
        {
            Units.Meter => baseValue / GetPrefixMultiplier(CurrentPrefix) * GetPrefixMultiplier((Prefix)targetPrefix),
            Units.Inch => baseValue / 0.0254m / GetPrefixMultiplier(CurrentPrefix) * GetPrefixMultiplier((Prefix)targetPrefix),
            Units.Foot => baseValue / 0.3048m / GetPrefixMultiplier(CurrentPrefix) * GetPrefixMultiplier((Prefix)targetPrefix),
            Units.Yard => baseValue / 0.9144m / GetPrefixMultiplier(CurrentPrefix) * GetPrefixMultiplier((Prefix)targetPrefix),
            Units.Mile => baseValue / 1609.344m / GetPrefixMultiplier(CurrentPrefix) * GetPrefixMultiplier((Prefix)targetPrefix),
            _ => throw new ArgumentOutOfRangeException(nameof(targetUnit), targetUnit, null)
        };

        return targetBaseValue;
    }

    public override string PrintUnit()
    {
        if ((Units)Unit == Units.Foot)
            return CurrentPrefix == Prefix.None ? "Feet" : CurrentPrefix.ToString() + "feet";
        else if ((Units)Unit == Units.Inch)
            return CurrentPrefix == Prefix.None ? "Inches" : CurrentPrefix.ToString() + "inches";
        return CurrentPrefix == Prefix.None ? Unit.ToString() + "s" : CurrentPrefix.ToString() + Unit.ToString().ToLower() + "s";
    }

    public override string PrintUnitAbbreviation()
    {
        var prefixAbbreviation = GetPrefixAbbreviation(CurrentPrefix);

        return Unit switch
        {
            Units.Meter => prefixAbbreviation + "m",
            Units.Inch => prefixAbbreviation + "in",
            Units.Foot => prefixAbbreviation + "ft",
            Units.Yard => prefixAbbreviation + "yd",
            Units.Mile => prefixAbbreviation + "mi",
            _ => throw new ArgumentOutOfRangeException(nameof(Unit), Unit, null)
        };
    }
}