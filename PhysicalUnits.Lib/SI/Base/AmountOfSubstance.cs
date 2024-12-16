namespace PhysicalUnits.Lib.SI.Base;

public class AmountOfSubstance : Unit
{
    public AmountOfSubstance(decimal value, Prefix prefix = Prefix.None)
        : base(value, prefix)
    { }

    public override string UnitName => "Moles";
    public override string UnitAbbreviation => "mols";
}