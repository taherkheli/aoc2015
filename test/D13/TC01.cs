using aoc.D13;

namespace aoc.test.D13
{
  public class TC01
  {
    [Theory]
    [InlineData(330, "initial.txt", false)]
    [InlineData(664, "input.txt", false)]
    [InlineData(640, "input.txt", true)]
    public void D13test(long expected, string input, bool isPartII)
    {
      var dinnerTable = new DinnerTable((Parser.Parse("./D13/" + input)));
      var actual = dinnerTable.GetTotalChangeInHappiness(isPartII);
      Assert.Equal(expected, actual);
    }
  }
}
