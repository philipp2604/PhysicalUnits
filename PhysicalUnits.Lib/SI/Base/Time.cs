namespace PhysicalUnits.Lib.SI.Base;

public class Time : Unit
{
    public Time(decimal value, Prefix prefix = Prefix.None)
        : base(value, prefix)
    { }

    public override string UnitName => "Seconds";
    public override string UnitAbbreviation => "s";
}