using aoc.D23;

namespace aoc.test.D23
{
  public class TC01
  {
    private readonly Instruction[] input = Parser.Parse("./D23/input.txt");

    [Theory]
    [InlineData(170, false)]
    [InlineData(247, true)]
    public void D23test1(uint expected, bool isPartII)
    {
      var computer = new Computer(input);
      computer.Execute(isPartII);
      var actual = computer.B;
      Assert.Equal(expected, actual);
    }
  }
}
