using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalUnits.Lib.SI.Base;

public class Temperature(decimal value, Temperature.Units unit, PhysicalQuantity.Prefix prefix = PhysicalQuantity.Prefix.None) : PhysicalQuantity(value, unit, prefix)
{
    public enum Units
    {
        Celsius,
        Fahrenheit,
        Kelvin
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
            throw new ArgumentException("Invalid target unit for Temperature", nameof(targetUnit));

        decimal baseValue = Unit switch
        {
            Units.Celsius => _value,
            Units.Fahrenheit => (_value - 32m) * 5m / 9m,
            Units.Kelvin => _value - 273.15m,
            _ => throw new ArgumentOutOfRangeException(nameof(Unit), Unit, null)
        };

        decimal targetBaseValue = targetUnit switch
        {
            Units.Celsius => baseValue,
            Units.Fahrenheit => (baseValue * 9m / 5m) + 32m,
            Units.Kelvin => baseValue + 273.15m,
            _ => throw new ArgumentOutOfRangeException(nameof(targetUnit), targetUnit, null)
        };

        return targetBaseValue / GetPrefixMultiplier(CurrentPrefix) * GetPrefixMultiplier((Prefix)targetPrefix);
    }

    public override string PrintUnit()
    {
        return CurrentPrefix == Prefix.None ? Unit.ToString() : CurrentPrefix.ToString() + Unit.ToString().ToLower();
    }

    public override string PrintUnitAbbreviation()
    {
        var prefixAbbreviation = GetPrefixAbbreviation(CurrentPrefix);

        return Unit switch
        {
            Units.Celsius => prefixAbbreviation + "°C",
            Units.Fahrenheit => prefixAbbreviation + "°F",
            Units.Kelvin => prefixAbbreviation + "K",
            _ => throw new ArgumentOutOfRangeException(nameof(Unit), Unit, null)
        };
    }
}