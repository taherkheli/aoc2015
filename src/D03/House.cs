namespace aoc.D03
{
	public class House
  {
    private readonly int _x;
    private readonly int _y;
    private int _visitCount;

    public House(int x, int y)
    {
      _x = x;
      _y = y;
      _visitCount = 1; //creation implies a visit 
    }

    public int X { get => _x; }
    public int Y { get => _y; }

    public int VisitCount { get => _visitCount; set => _visitCount = value; }
  }
}
