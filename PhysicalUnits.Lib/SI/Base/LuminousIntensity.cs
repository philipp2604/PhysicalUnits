namespace PhysicalUnits.Lib.SI.Base;

public class LuminousIntensity : Unit
{
    public LuminousIntensity(decimal value, Prefix prefix = Prefix.None)
        : base(value, prefix)
    { }

    public override string UnitName => "Candelas";
    public override string UnitAbbreviation => "cd";
}