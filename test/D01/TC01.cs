using aoc.D01;

namespace aoc.test.D01
{
  public class TC01
  {
    readonly string input = Parser.Parse("./D01/input.txt");

    [Theory]
    [InlineData(138, false)]
    [InlineData(1771, true)]
    public void D01test(int expected, bool isPartII)
    {
      var actual = Building.Solve(input, isPartII);
      Assert.Equal(expected, actual);
    }
  }
}
