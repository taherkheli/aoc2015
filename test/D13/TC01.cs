using aoc.D13;

namespace aoc.test.D13
{
  public class TC01
  {
    private readonly (List<string>, Dictionary<(string, string), int>) initial = Parser.Parse("./D13/initial.txt");
    private readonly (List<string>, Dictionary<(string, string), int>) input = Parser.Parse("./D13/input.txt");

    [Theory]
    [InlineData(330)]
    public void D13test1(int expected)
    {
      var dinnerTable = new DinnerTable(initial);
      var actual = dinnerTable.GetTotalChangeInHappiness();
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(664, false)]
    [InlineData(640, true)]
    public void D13test2(long expected, bool isPartII)
    {
      var dinnerTable = new DinnerTable(input);
      var actual = dinnerTable.GetTotalChangeInHappiness(isPartII);
      Assert.Equal(expected, actual);
    }
  }
}
