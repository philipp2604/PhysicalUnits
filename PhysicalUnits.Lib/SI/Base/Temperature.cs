namespace PhysicalUnits.Lib.SI.Base;

public class Temperature : Unit
{
    public Temperature(decimal value, Prefix prefix = Prefix.None)
        : base(value, prefix)
    { }

    public override string UnitName => "Kelvins";
    public override string UnitAbbreviation => "K";
}