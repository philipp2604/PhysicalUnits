using PhysicalUnits.Lib.SI.Base;

namespace PhysicalUnits.Test.SI.Base;

public class Time_Class_UnitTests
{
    [Fact]
    public void GetValue_ReturnsCorrectValue()
    {
        var time = new Time(100, Time.Units.Second);
        var result = time.GetValue();

        Assert.Equal(100, result);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromSecondsInMinutes()
    {
        var time = new Time(60, Time.Units.Second);
        var result = time.GetValueInUnit(Time.Units.Minute);

        Assert.Equal(1, result);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromSecondsInHours()
    {
        var time = new Time(3600, Time.Units.Second);
        var result = time.GetValueInUnit(Time.Units.Hour);

        Assert.Equal(1, result);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromMinutesInSeconds()
    {
        var time = new Time(1, Time.Units.Minute);
        var result = time.GetValueInUnit(Time.Units.Second);

        Assert.Equal(60, result);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromMinutesInHours()
    {
        var time = new Time(60, Time.Units.Minute);
        var result = time.GetValueInUnit(Time.Units.Hour);

        Assert.Equal(1, result);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromHoursInSeconds()
    {
        var time = new Time(1, Time.Units.Hour);
        var result = time.GetValueInUnit(Time.Units.Second);

        Assert.Equal(3600, result);
    }

    [Fact]
    public void GetValueInUnit_ReturnsCorrectValueFromHoursInMinutes()
    {
        var time = new Time(1, Time.Units.Hour);
        var result = time.GetValueInUnit(Time.Units.Minute);

        Assert.Equal(60, result);
    }

    [Fact]
    public void SetValueInUnit_SetsValueCorrectly()
    {
        var time = new Time(100, Time.Units.Second);
        time.SetValueInUnit(1, Time.Units.Hour);

        Assert.Equal(1, time.GetValue());
    }

    [Fact]
    public void PrintUnit_PrintsCorrectUnit()
    {
        var time = new Time(100, Time.Units.Second);
        var result = time.PrintUnit();

        Assert.Equal("Seconds", result);
    }

    [Fact]
    public void PrintUnitAbbreviation_PrintsCorrectAbbreviation()
    {
        var time = new Time(100, Time.Units.Second);
        var result = time.PrintUnitAbbreviation();

        Assert.Equal("s", result);
    }
}