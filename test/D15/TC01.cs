using aoc.D15;

namespace aoc.test.D15
{
  public class TC01
  {
    readonly CookieMaker cookieMaker = new ((Parser.Parse("./D15/input.txt")));

    [Theory]
    [InlineData(13882464, false)]
    [InlineData(11171160, true)]
    public void D15test1(int expected, bool isPartII)
    {
      var actual = cookieMaker.GetHighestScoringCookie(isPartII);
      Assert.Equal(expected, actual);
    }
  }
}
