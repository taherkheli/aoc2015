using aoc.D03;

namespace aoc.test.D03
{
	public class TC01
	{
		Dir[] dirs = Parser.Parse("./D03/input.txt");

		[Fact]
		public void PartI()
		{
			int expected = 2572;
      var solver = new Solve(dirs);
      int actual = solver.PartI();        
			Assert.Equal(expected, actual);
		}

    [Fact]
    public void PartII()
    {
      int expected = 2631;
      var solver = new Solve(dirs);
      int actual = solver.PartII();
      Assert.Equal(expected, actual);
    }
  }
}
