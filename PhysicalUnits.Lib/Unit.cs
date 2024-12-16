namespace PhysicalUnits.Lib;

public abstract class Unit
{
    private Decimal _valueInBaseUnit;
    private Decimal _originalValue;
    private Prefix _originalPrefix;

    private static readonly Dictionary<Prefix, Decimal> PrefixFactors = new Dictionary<Prefix, Decimal>
    {
        { Prefix.Pico, 1e-12M },
        { Prefix.Nano, 1e-9M },
        { Prefix.Micro, 1e-6M },
        { Prefix.Milli, 1e-3M },
        { Prefix.Centi, 1e-2M },
        { Prefix.Deci, 1e-1M },
        { Prefix.None, 1M },
        { Prefix.Deca, 1e1M },
        { Prefix.Hecto, 1e2M },
        { Prefix.Kilo, 1e3M },
        { Prefix.Mega, 1e6M },
        { Prefix.Giga, 1e9M },
        { Prefix.Tera, 1e12M }
    };

    private static readonly Dictionary<Prefix, string> PrefixAbbreviations = new Dictionary<Prefix, string>
    {
        { Prefix.Pico, "p" },
        { Prefix.Nano, "n" },
        { Prefix.Micro, "µ" },
        { Prefix.Milli, "m" },
        { Prefix.Centi, "c" },
        { Prefix.Deci, "d" },
        { Prefix.None, "" },
        { Prefix.Deca, "da" },
        { Prefix.Hecto, "h" },
        { Prefix.Kilo, "k" },
        { Prefix.Mega, "M" },
        { Prefix.Giga, "G" },
        { Prefix.Tera, "T" }
    };

    protected Unit(Decimal value, Prefix prefix = Prefix.None)
    {
        if (!PrefixFactors.ContainsKey(prefix))
            throw new ArgumentException("Invalid prefix!");
        SetValue(value, prefix);
    }

    public abstract string UnitName { get; }
    public abstract string UnitAbbreviation { get; }

    public void SetValue(Decimal value, Prefix prefix = Prefix.None)
    {
        if (!PrefixFactors.ContainsKey(prefix))
            throw new ArgumentException("Invalid prefix!");

        _originalValue = value;
        _originalPrefix = prefix;
        _valueInBaseUnit = ConvertToBaseUnit(value, prefix);
    }

    public Decimal GetValue(Prefix? prefix = null)
    {
        if (prefix == null)
            prefix = _originalPrefix;

        if (!PrefixFactors.ContainsKey((Prefix)prefix))
            throw new ArgumentException("Invalid prefix.");

        return _valueInBaseUnit / PrefixFactors[(Prefix)prefix];
    }

    public string GetName()
    {
        var prefixStr = Enum.GetName(typeof(Prefix), _originalPrefix) ?? "";
        return $"{prefixStr}{UnitName}";
    }

    public string GetAbbreviation()
    {
        if (!PrefixAbbreviations.ContainsKey(_originalPrefix))
            throw new ArgumentException("Invalid prefix.");

        var prefixAbbr = PrefixAbbreviations[_originalPrefix];
        return $"{prefixAbbr}{UnitAbbreviation}";
    }

    public enum Prefix
    {
        Pico, // 1e-12
        Nano, // 1e-9
        Micro, // 1e-6
        Milli, // 1e-3
        Centi, // 1e-2
        Deci, // 1e-1
        None, // 1
        Deca, // 1e1
        Hecto, // 1e2
        Kilo, // 1e3
        Mega, // 1e6
        Giga, // 1e9
        Tera // 1e12
    }

    protected static Decimal ConvertToBaseUnit(Decimal value, Prefix prefix)
    {
        if (!PrefixFactors.ContainsKey(prefix))
        {
            throw new ArgumentException("Invalid prefix");
        }

        return value * PrefixFactors[prefix];
    }
}