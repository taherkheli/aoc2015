using aoc.D10;

namespace aoc.test.D10
{
  public class TC01
  {
    [Theory]
    [InlineData(6, "111221", 1)]
    [InlineData(360154, "1113122113", 40)]
    [InlineData(5103798, "1113122113", 50)]
    public void D10test(long expected, string input, int iterations)
    {
      var actual = LookAndSay.Solve(input, iterations);
      Assert.Equal(expected, actual);
    }
  }
}
