using aoc.D07;

namespace aoc.test.D07
{
  public class TC01
  {
    [Theory]
    [InlineData(956, "input.txt", false)]
    [InlineData(40149, "input.txt", true)]
    public void D07test(long expected, string input, bool isPartII)
    {
      var circuit = new Circuit(Parser.Parse("./D07/" + input));
      var actual = circuit.Emulate(isPartII);
      Assert.Equal(expected, actual);
    }
  }
}
