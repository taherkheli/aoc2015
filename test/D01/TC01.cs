using aoc.D01;
using Xunit;

namespace aoc.test.D01
{
	public class TC01
	{
		string input = Parser.Parse("./D01/input.txt");

		[Fact]
		public void PartI()
		{
			var expected = 138;

			var actual = Helper.GetFloor(input);

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PartII()
		{
			var expected = 1771;
			var actual = Helper.IndexAtEnteringBasement(input);

			Assert.Equal(expected, actual);
		}
	}
}
