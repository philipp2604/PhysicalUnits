namespace PhysicalUnits.Lib.SI.Base;

public class ElectricCurrent : Unit
{
    public ElectricCurrent(decimal value, Prefix prefix = Prefix.None)
        : base(value, prefix)
    { }

    public override string UnitName => "Amperes";
    public override string UnitAbbreviation => "A";
}