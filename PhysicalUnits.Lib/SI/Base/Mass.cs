namespace PhysicalUnits.Lib.SI.Base;

public class Mass : Unit
{
    public Mass(decimal value, Prefix prefix = Prefix.None)
        : base(value, prefix)
    { }

    public override string UnitName => "Grams";
    public override string UnitAbbreviation => "g";
}