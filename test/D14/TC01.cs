using aoc.D14;

namespace aoc.test.D14
{
  public class TC01
  {
    Race race = new Race((Parser.Parse("./D14/input.txt")));

    [Theory]
    [InlineData(2640, 2503)]
    public void D14test1(long expected, int duration)
    {
      var actual = race.GetDistanceTravelledByWinner(duration);
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1102, 2503)]
    public void D14test2(long expected, int duration)
    {
      var actual = race.GetPointsAccumulatedByWinner(duration);
      Assert.Equal(expected, actual);
    }
  }
}
