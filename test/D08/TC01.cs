using aoc.D08;

namespace aoc.test.D08
{
  public class TC01
  {
    private readonly string[] strings = [.. File.ReadLines("./D08/input.txt")];

    [Theory]
    [InlineData(1350, false)]
    [InlineData(2085, true)]
    public void D08test(long expected, bool isPartII)
    {
      var parser = new StringParser(strings);
      var actual = parser.Solve(isPartII);
      Assert.Equal(expected, actual);
    }
  }
}
