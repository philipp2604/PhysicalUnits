using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicalUnits.Lib.SI.Base;

public class AmountOfSubstance(decimal value, PhysicalQuantity.Prefix prefix = PhysicalQuantity.Prefix.None) : PhysicalQuantity(value, Units.Mole, prefix)
{
    public enum Units
    {
        Mole
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
            Units.Mole => prefixAbbreviation + "mol",
            _ => throw new ArgumentOutOfRangeException(nameof(Unit), Unit, null)
        };
    }
}
