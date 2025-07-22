using aoc.D01;

namespace aoc.test.D01
{
  public class TC01
  {
    string input = Parser.Parse("./D01/input.txt");

    [Fact]
    public void PartI()
    {
      var expected = 138;
      var actual = Building.Solve(input);
      Assert.Equal(expected, actual);
    }

    [Fact]
    public void PartII()
    {
      var expected = 1771;
      var actual = Building.Solve(input, true);
      Assert.Equal(expected, actual);
    }
  }
}
