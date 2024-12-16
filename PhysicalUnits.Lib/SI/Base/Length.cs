namespace PhysicalUnits.Lib.SI.Base;

public class Length : Unit
{
    public Length(decimal value, Prefix prefix = Prefix.None)
        : base(value, prefix)
    { }

    public override string UnitName => "Meters";
    public override string UnitAbbreviation => "m";
}