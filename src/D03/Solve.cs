namespace aoc.D03
{
  public class Solve
  {
    private readonly Dir[] _moves;

    public Solve(Dir[] moves)
    {
      _moves = moves;
    }

    public int PartI()
    {
      var santa = new Santa();
      return santa.Simulate(_moves);
    }

    public int PartII()
    {
      var santa = new Santa();
      return santa.SimulatePartII(_moves);
    }
  }
}
