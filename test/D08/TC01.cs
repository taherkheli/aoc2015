using aoc.D08;

namespace aoc.test.D08
{
  public class TC01
  {
    [Theory]
    [InlineData(1350, "input.txt", false)]
    [InlineData(2085, "input.txt", true)]
    public void D08test(long expected, string input, bool isPartII)
    {
      var parser = new StringParser([.. File.ReadLines("./D08/" + input)]);
      var actual = parser.Solve(isPartII);
      Assert.Equal(expected, actual);
    }
  }
}
