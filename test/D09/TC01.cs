using aoc.D09;

namespace aoc.test.D09
{
  public class TC01
  {
    private readonly (List<string>, Dictionary<(string, string), int>) initial = Parser.Parse("./D09/initial.txt");
    private readonly (List<string>, Dictionary<(string, string), int>) input = Parser.Parse("./D09/input.txt");

    [Theory]
    [InlineData(605, false)]
    [InlineData(982, true)]
    public void D09test1(long expected, bool isPartII)
    {
      var travel = new Travel(initial);
      var actual = travel.GetDistance(isPartII);
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(207, false)]
    [InlineData(804, true)]
    public void D09test2(long expected, bool isPartII)
    {
      var travel = new Travel(input);
      var actual = travel.GetDistance(isPartII);
      Assert.Equal(expected, actual);
    }
  }
}
