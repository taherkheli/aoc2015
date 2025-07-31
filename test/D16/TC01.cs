using aoc.D16;

namespace aoc.test.D16
{
  public class TC01
  {
    readonly Identifier identifer = new((Parser.Parse("./D16/input.txt")));
    readonly Dictionary<string, int> senderData = new()
    {
      { "children", 3 },
      { "cats", 7 },
      { "samoyeds", 2 },
      { "pomeranians", 3 },
      { "akitas", 0 },
      { "vizslas", 0 },
      { "goldfish", 5 },
      { "trees", 3 },
      { "cars", 2 },
      { "perfumes", 1 }
    };

    [Theory]
    [InlineData(373, false)]
    [InlineData(260, true)]
    public void D16test(int expected, bool isPartII)
    {
      var actual = identifer.GetSenderAuntId(senderData, isPartII);
      Assert.Equal(expected, actual);
    }
  }
}
