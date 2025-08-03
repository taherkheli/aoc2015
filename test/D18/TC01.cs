using aoc.D18;

namespace aoc.test.D18
{
  public class TC01
  {
    private readonly int[,] initial = Parser.Parse("./D18/initial.txt");
    private readonly int[,] input = Parser.Parse("./D18/input.txt");

    [Theory]
    [InlineData(17, 5, true)]
    public void D18test1(int expected, int steps, bool isPartII)
    {
      var grid = new Grid(initial);
      var actual = grid.OnLightsCount(steps, isPartII);
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(821, 100, false)]
    [InlineData(886, 100, true)]
    public void D18test2(int expected, int steps, bool isPartII)
    {
      var grid = new Grid(input);
      var actual = grid.OnLightsCount(steps, isPartII);
      Assert.Equal(expected, actual);
    }
  }
}
