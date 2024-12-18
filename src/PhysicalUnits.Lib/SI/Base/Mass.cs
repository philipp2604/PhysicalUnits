namespace PhysicalUnits.Lib.SI.Base;

public class Mass(decimal value, Mass.Units unit, PhysicalQuantity.Prefix prefix = PhysicalQuantity.Prefix.None) : PhysicalQuantity(value, unit, prefix)
{
    public enum Units
    {
        Gram,
        Pound
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2208:Argumentausnahmen korrekt instanziieren", Justification = "<Ausstehend>")]
    public override decimal GetValueInUnit(Enum targetUnit, Prefix? targetPrefix = Prefix.None)
    {
        targetUnit ??= Unit;

        targetPrefix ??= CurrentPrefix;

        if (targetUnit is not Units)
            throw new ArgumentException("Invalid target unit for Mass", nameof(targetUnit));

        var baseValue = Unit switch
        {
            Units.Gram => _value,
            Units.Pound => _value * (decimal)453.592,
            _ => throw new ArgumentOutOfRangeException(nameof(Unit), Unit, null)
        };

        var targetBaseValue = targetUnit switch
        {
            Units.Gram => baseValue / GetPrefixMultiplier(CurrentPrefix) * GetPrefixMultiplier((Prefix)targetPrefix),
            Units.Pound => baseValue / (decimal)453.592 / GetPrefixMultiplier(CurrentPrefix) * GetPrefixMultiplier((Prefix)targetPrefix),
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
            Units.Gram => prefixAbbreviation + "g",
            Units.Pound => prefixAbbreviation + "lb",
            _ => throw new ArgumentOutOfRangeException(nameof(Unit), Unit, null)
        };
    }
}