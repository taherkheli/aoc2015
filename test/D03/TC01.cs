using aoc.D03;
using Xunit;

namespace aoc.test.D03
{
	public class TC01
	{
		Dir[] dirs = Parser.Parse("./D03/input.txt");

		[Fact]
		public void PartI()
		{
			int expected = 2572;

			var grid = new Grid(0, 0);

			foreach (var dir in dirs)
				grid.Move(dir);

			int actual = grid.VisitedHouses.Count;

			Assert.Equal(expected, actual);
		}

		[Fact]
		public void PartII()
		{
			int expected = 2631;

			var grid_Santa = new Grid(0, 0);
			var grid_Robo_Santa = new Grid(0, 0);

			for (int i = 0; i < dirs.Length; i++)
			{
				if (i % 2 == 0)
					grid_Santa.Move(dirs[i]);
				else
					grid_Robo_Santa.Move(dirs[i]);
			}

			var union = Utils.GetUnion(grid_Santa.VisitedHouses, grid_Robo_Santa.VisitedHouses);

			int actual = union.Count;

			Assert.Equal(expected, actual);
		}
	}
}
