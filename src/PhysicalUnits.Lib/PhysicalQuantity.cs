using System.Globalization;

namespace PhysicalUnits.Lib;

public abstract class PhysicalQuantity(decimal value, Enum unit, PhysicalQuantity.Prefix prefix)
{
    protected decimal _value = value;

    public Enum Unit { get; protected set; } = unit;
    public Prefix CurrentPrefix { get; protected set; } = prefix;

    public enum Prefix
    {
        Nano = -9,
        Micro = -6,
        Milli = -3,
        Centi = -2,
        Deci = -1,
        None = 0,
        Deca = 1,
        Hecto = 2,
        Kilo = 3,
        Mega = 6,
        Giga = 9
    }

    protected static decimal GetPrefixMultiplier(Prefix prefix)
    {
        return (decimal)Math.Pow(10, (double)prefix);
    }

    protected virtual string GetPrefixAbbreviation(Prefix prefix)
    {
        return prefix switch
        {
            Prefix.None => "",
            Prefix.Nano => "n",
            Prefix.Micro => "µ",
            Prefix.Milli => "m",
            Prefix.Centi => "c",
            Prefix.Deci => "d",
            Prefix.Deca => "da",
            Prefix.Hecto => "h",
            Prefix.Kilo => "k",
            Prefix.Mega => "M",
            Prefix.Giga => "G",
            _ => throw new ArgumentOutOfRangeException(nameof(prefix), prefix, null)
        };
    }

    public virtual decimal GetValue(Prefix? targetPrefix = Prefix.None)
    {
        targetPrefix ??= CurrentPrefix;
        return _value / GetPrefixMultiplier((Prefix)targetPrefix);
    }

    public abstract decimal GetValueInUnit(Enum targetUnit, Prefix? targetPrefix = Prefix.None);

    public virtual void SetValue(decimal value, Prefix? targetPrefix = null)
    {
        if (targetPrefix != null)
        {
            CurrentPrefix = (Prefix)targetPrefix;
            _value = value * GetPrefixMultiplier(CurrentPrefix);
        }
        else
        {
            _value = value;
        }
    }

    public virtual void SetValueInUnit(decimal value, Enum unit, Prefix prefix = Prefix.None)
    {
        _value = value;
        Unit = unit;
        CurrentPrefix = prefix;
    }

    public abstract string PrintUnit();

    public abstract string PrintUnitAbbreviation();

    public string PrintValue()
    {
        return $"{_value.ToString(CultureInfo.InvariantCulture)} {PrintUnitAbbreviation()}";
    }

    public override string ToString()
    {
        return PrintValue();
    }
}