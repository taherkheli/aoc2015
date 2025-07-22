using aoc.D06;

namespace aoc.test.D06
{
	public class TC01
	{
    [Theory]
    [InlineData(543903, "input.txt", false)]
    [InlineData(14687245, "input.txt", true)]
    public void D06test(long expected, string input, bool isPartII)
    {
      var grid = new Grid();
      var actual = grid.Execute(Parser.Parse("./D06/" + input), isPartII);
      Assert.Equal(expected, actual);
    }
  }
}
