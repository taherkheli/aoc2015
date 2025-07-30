using aoc.D11;

namespace aoc.test.D11
{
  public class TC01
  {
    [Theory]
    [InlineData("hepxxyzz", "hepxcrrq")]
    [InlineData("heqaabcc", "hepxxyzz")]
    public void D11test(string expected, string input)
    {
      var actual = Password.GetNextValidPassword(input);
      Assert.Equal(expected, actual);
    }
  }
}
