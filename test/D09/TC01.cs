using aoc.D09;

namespace aoc.test.D09
{
  public class TC01
  {
    [Theory]
    [InlineData(605, "initial.txt", false)]
    [InlineData(982, "initial.txt", true)]
    [InlineData(207, "input.txt", false)]
    [InlineData(804, "input.txt", true)]
    public void D09test(long expected, string input, bool isPartII)
    {
      var travel = new Travel(Parser.Parse("./D09/" + input));
      var actual = travel.GetDistance(isPartII);
      Assert.Equal(expected, actual);
    }
  }
}
