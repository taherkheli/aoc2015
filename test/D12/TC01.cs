using aoc.D12;
using System.IO;

namespace aoc.test.D12
{
  public class TC01
  {
    private readonly string jsonText = File.ReadAllText("./D12/input.txt");

    [Theory]
    [InlineData(156366)]
    public void D11test1(int expected)
    {
      var actual = JsonPartI.CountNumbers(jsonText);
      Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(96852)]
    public void D11test2(int expected)
    {
      var actual = JsonPartII.CountNumbers(jsonText);
      Assert.Equal(expected, actual);
    }
  }
}
