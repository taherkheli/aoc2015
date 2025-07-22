using aoc.D04;

namespace aoc.test.D04
{
  public class TC01
	{
    string input = "iwrupvqb";

    [Fact]
		public void PartI()
		{
			int expected = 346386;
      var mD5Hash = new MD5Hash(input);
      int actual = mD5Hash.PartI();      
			Assert.Equal(expected, actual);
		}

    [Fact]
    public void PartII()
    {
      int expected = 9958218;
      var mD5Hash = new MD5Hash(input);
      int actual = mD5Hash.PartII();
      Assert.Equal(expected, actual);
    }
  }
}
