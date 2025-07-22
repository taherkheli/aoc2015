using aoc.D02;

namespace aoc.test.D02
{
	public class TC01
	{
		Box[] boxes = Parser.Parse("./D02/input.txt");

		[Theory]
		[InlineData(2, 3, 4, 58)]
		[InlineData(1, 1, 10, 43)]
		public void InitialI(int x1, int x2, int x3, int expected)
		{
			var box = new Box(x1, x2, x3);
			int actual = box.GetWrapperPaperNeeded();
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(2, 3, 4, 34)]
		[InlineData(1, 1, 10, 14)]
		public void InitialII(int x1, int x2, int x3, int expected)
		{
			var box = new Box(x1, x2, x3);
			int actual = box.GetRibbonNeeded();
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PartI()
		{
			var expected = 1606483;
			var actual = Calculate.WrappingPaper(boxes);
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PartII()
		{
			var expected = 3842356;
			var actual = Calculate.Ribbon(boxes);
			Assert.Equal(expected, actual);
		}
	}
}
