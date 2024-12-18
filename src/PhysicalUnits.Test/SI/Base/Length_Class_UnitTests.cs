using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test.SI.Base;

public class Length_Class_UnitTests
{
    [Fact]
    public void GetValue_ReturnsCorrectValue()
    {
        var length = new Length(100, Length.Units.Meter);
        var result = length.GetValue();

        Assert.Equal(100, result);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromMetersInInches()
    {
        var length = new Length(1, Length.Units.Meter);
        var result = length.GetValueInUnit(Length.Units.Inch);

        Assert.Equal(39.3701m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromMetersInFeet()
    {
        var length = new Length(1, Length.Units.Meter);
        var result = length.GetValueInUnit(Length.Units.Foot);

        Assert.Equal(3.2808m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromMetersInYards()
    {
        var length = new Length(1, Length.Units.Meter);
        var result = length.GetValueInUnit(Length.Units.Yard);

        Assert.Equal(1.0936m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromMetersInMiles()
    {
        var length = new Length(1, Length.Units.Meter);
        var result = length.GetValueInUnit(Length.Units.Mile);

        Assert.Equal(0.0006m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromInchesInMeters()
    {
        var length = new Length(39.3701m, Length.Units.Inch);
        var result = length.GetValueInUnit(Length.Units.Meter);

        Assert.Equal(1, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromInchesInFeet()
    {
        var length = new Length(1, Length.Units.Inch);
        var result = length.GetValueInUnit(Length.Units.Foot);

        Assert.Equal(0.0833m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromInchesInYards()
    {
        var length = new Length(1, Length.Units.Inch);
        var result = length.GetValueInUnit(Length.Units.Yard);

        Assert.Equal(0.0278m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromInchesInMiles()
    {
        var length = new Length(1, Length.Units.Inch);
        var result = length.GetValueInUnit(Length.Units.Mile);

        Assert.Equal(0.00001578m, result, 8);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromFeetInMeters()
    {
        var length = new Length(1, Length.Units.Foot);
        var result = length.GetValueInUnit(Length.Units.Meter);

        Assert.Equal(0.3048m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromFeetInInches()
    {
        var length = new Length(1, Length.Units.Foot);
        var result = length.GetValueInUnit(Length.Units.Inch);

        Assert.Equal(12, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromFeetInYards()
    {
        var length = new Length(1, Length.Units.Foot);
        var result = length.GetValueInUnit(Length.Units.Yard);

        Assert.Equal(0.3333m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromFeetInMiles()
    {
        var length = new Length(1, Length.Units.Foot);
        var result = length.GetValueInUnit(Length.Units.Mile);

        Assert.Equal(0.00018939m, result, 8);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromYardsInMeters()
    {
        var length = new Length(1, Length.Units.Yard);
        var result = length.GetValueInUnit(Length.Units.Meter);

        Assert.Equal(0.9144m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromYardsInInches()
    {
        var length = new Length(1, Length.Units.Yard);
        var result = length.GetValueInUnit(Length.Units.Inch);

        Assert.Equal(36, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromYardsInFeet()
    {
        var length = new Length(1, Length.Units.Yard);
        var result = length.GetValueInUnit(Length.Units.Foot);

        Assert.Equal(3, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromYardsInMiles()
    {
        var length = new Length(1, Length.Units.Yard);
        var result = length.GetValueInUnit(Length.Units.Mile);

        Assert.Equal(0.00056818m, result, 8);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromMilesInMeters()
    {
        var length = new Length(1, Length.Units.Mile);
        var result = length.GetValueInUnit(Length.Units.Meter);

        Assert.Equal(1609.344m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromMilesInInches()
    {
        var length = new Length(1, Length.Units.Mile);
        var result = length.GetValueInUnit(Length.Units.Inch);

        Assert.Equal(63360m, result, 4);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromMilesInFeet()
    {
        var length = new Length(1, Length.Units.Mile);
        var result = length.GetValueInUnit(Length.Units.Foot);

        Assert.Equal(5280, result, 4);
    }

    [Fact]
    public void SetValueInUnit_SetsValueCorrectly()
    {
        var length = new Length(100, Length.Units.Meter);
        length.SetValueInUnit(1, Length.Units.Mile);

        Assert.Equal(1, length.GetValue());
    }

    [Fact]
    public void PrintUnit_PrintsCorrectUnitForMeters()
    {
        var length = new Length(100, Length.Units.Meter);
        var result = length.PrintUnit();

        Assert.Equal("Meters", result);
    }

    [Fact]
    public void PrintUnit_PrintsCorrectUnitForInches()
    {
        var length = new Length(100, Length.Units.Inch);
        var result = length.PrintUnit();

        Assert.Equal("Inches", result);
    }

    [Fact]
    public void PrintUnit_PrintsCorrectUnitForFeet()
    {
        var length = new Length(100, Length.Units.Foot);
        var result = length.PrintUnit();

        Assert.Equal("Feet", result);
    }

    [Fact]
    public void PrintUnitAbbreviation_PrintsCorrectAbbreviation()
    {
        var length = new Length(100, Length.Units.Mile);
        var result = length.PrintUnitAbbreviation();

        Assert.Equal("mi", result);
    }
}