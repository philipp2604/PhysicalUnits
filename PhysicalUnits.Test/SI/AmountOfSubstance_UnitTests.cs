using PhysicalUnits.Lib;
using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test.SI;

public class AmountOfSubstanceClass_UnitTests
{
    [Fact]
    public void AmountOfSubstance_InitialValueInBaseUnit_ShouldBeCorrect()
    {
        //Arrange
        var amount = new AmountOfSubstance(200, Unit.Prefix.Milli);

        //Act
        var valueInBaseUnit = amount.GetValue(Unit.Prefix.None);

        //Assert
        Assert.Equal(0.200M, valueInBaseUnit);
    }

    [Fact]
    public void AmountOfSubstance_SetValue_ShouldUpdateValueCorrectly()
    {
        //Arrange
        var amount = new AmountOfSubstance(200, Unit.Prefix.Milli);

        //Act
        amount.SetValue(500, Unit.Prefix.Kilo);
        var valueInBaseUnit = amount.GetValue(Unit.Prefix.None);

        //Assert
        Assert.Equal(500000.0M, valueInBaseUnit);
    }

    [Fact]
    public void AmountOfSubstance_GetValue_ShouldReturnCorrectValue()
    {
        //Arrange
        var amount = new AmountOfSubstance(200, Unit.Prefix.Milli);

        //Act
        var value = amount.GetValue(Unit.Prefix.Milli);

        //Assert
        Assert.Equal(200.0M, value);
    }

    [Fact]
    public void AmountOfSubstance_GetValueWithDifferentPrefix_ShouldReturnConvertedValue()
    {
        //Arrange
        var amount = new AmountOfSubstance(200, Unit.Prefix.Milli);

        //Act
        var value = amount.GetValue(Unit.Prefix.Micro);

        //Assert
        Assert.Equal(200000, value);
    }

    [Fact]
    public void AmountOfSubstance_GetName_ShouldReturnCorrectName()
    {
        //Arrange
        var amount = new AmountOfSubstance(200, Unit.Prefix.Milli);

        //Act
        var name = amount.GetName();

        //Assert
        Assert.Equal("MilliMoles", name);
    }

    [Fact]
    public void AmountOfSubstance_GetAbbreviation_ShouldReturnCorrectName()
    {
        //Arrange
        var amount = new AmountOfSubstance(200, Unit.Prefix.Milli);

        //Act
        var abbreviation = amount.GetAbbreviation();

        //Assert
        Assert.Equal("mmols", abbreviation);
    }

    [Fact]
    public void AmountOfSubstance_GetValueWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Arrange
        var amount = new AmountOfSubstance(200, Unit.Prefix.Milli);

        //Assert
        Assert.Throws<ArgumentException>(() => amount.GetValue((Unit.Prefix)(-1)));
    }

    [Fact]
    public void AmountOfSubstance_ConstructorWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var amount = new AmountOfSubstance(200, (Unit.Prefix)(-1));
        }
        );
    }

    [Fact]
    public void AmountOfSubstance_SetValueWithInvalidPrefix_ShouldThrowArgumentException()
    {
        //Arrange
        var amount = new AmountOfSubstance(200, Unit.Prefix.Milli);

        //Assert
        Assert.Throws<ArgumentException>(() => amount.SetValue(200, (Unit.Prefix)(-1)));
    }
}