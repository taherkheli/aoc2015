using aoc.D05;
using Xunit;

namespace aoc.test.D05
{
  public class TC01
	{
    string[] strings = Parser.Parse("./D05/input.txt");

    [Fact]
		public void PartI()
		{
			int expected = 255;

      var niceStrings = new NiceStrings(strings);

      int actual = niceStrings.PartI();
      
			Assert.Equal(expected, actual);
		}

    [Fact]
    public void PartII()
    {
      int expected = 55;

      var niceStrings = new NiceStrings(strings);

      int actual = niceStrings.PartII();

      Assert.Equal(expected, actual);
    }
  }
}
