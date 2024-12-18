namespace PhysicalUnits.Lib.SI.Base;

public class Time(decimal value, Time.Units unit, PhysicalQuantity.Prefix prefix = PhysicalQuantity.Prefix.None) : PhysicalQuantity(value, unit, prefix)
{
    public enum Units
    {
        Second,
        Minute,
        Hour
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
            throw new ArgumentException("Invalid target unit for Time", nameof(targetUnit));

        var baseValue = Unit switch
        {
            Units.Second => _value,
            Units.Minute => _value * 60m,
            Units.Hour => _value * 3600m,
            _ => throw new ArgumentOutOfRangeException(nameof(Unit), Unit, null)
        };

        var targetBaseValue = targetUnit switch
        {
            Units.Second => baseValue / GetPrefixMultiplier(CurrentPrefix) * GetPrefixMultiplier((Prefix)targetPrefix),
            Units.Minute => baseValue / 60m / GetPrefixMultiplier(CurrentPrefix) * GetPrefixMultiplier((Prefix)targetPrefix),
            Units.Hour => baseValue / 3600m / GetPrefixMultiplier(CurrentPrefix) * GetPrefixMultiplier((Prefix)targetPrefix),
            _ => throw new ArgumentOutOfRangeException(nameof(targetUnit), targetUnit, null)
        };

        return targetBaseValue;
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
            Units.Second => prefixAbbreviation + "s",
            Units.Minute => prefixAbbreviation + "min",
            Units.Hour => prefixAbbreviation + "h",
            _ => throw new ArgumentOutOfRangeException(nameof(Unit), Unit, null)
        };
    }
}