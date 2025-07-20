namespace aoc.D03
{
  public class Santa
  {
    private int _x;
    private int _y;
    private int _xRobo;
    private int _yRobo;
    private Dictionary<(int, int), int> _map;

    public Santa()
    {
      _x = 0;
      _y = 0;
      _xRobo = 0;
      _yRobo = 0;
      _map = new Dictionary<(int, int), int>();
      _map.Add((0, 0), 1);  //santa delivers a present at origin
    }

    public int Simulate(Dir[] moves)
    {
      for (int i = 0; i < moves.Length; i++) 
      {
        switch (moves[i])
        {
          case Dir.North:
            _y++; 
            break;
          case Dir.South:
            _y--;
            break;
          case Dir.East:
            _x++;
            break;
          case Dir.West:
            _x--;
            break;
          case Dir.Unknown:
          default:
            throw new Exception("Oops!!! was not expected!");
        }

        if (_map.ContainsKey((_x, _y)))
          _map[(_x,_y)]++;
        else
          _map.Add((_x, _y), 1);
      }

      return _map.Count;
    }

    public int SimulatePartII(Dir[] moves)
    {
      _map[(_xRobo, _yRobo)]++; // roboSanta starts at the same house

      for (int i = 0; i < moves.Length; i++)
      {
        if (i % 2 == 0)  //even => santa moves
        {
          switch (moves[i])
          {
            case Dir.North:
              _y++;
              break;
            case Dir.South:
              _y--;
              break;
            case Dir.East:
              _x++;
              break;
            case Dir.West:
              _x--;
              break;
            case Dir.Unknown:
            default:
              throw new Exception("Oops!!! was not expected!");
          }

          if (_map.ContainsKey((_x, _y)))
            _map[(_x, _y)]++;
          else
            _map.Add((_x, _y), 1);
        }
        else // odd => robo moves 
        {
          switch (moves[i])
          {
            case Dir.North:
              _yRobo++;
              break;
            case Dir.South:
              _yRobo--;
              break;
            case Dir.East:
              _xRobo++;
              break;
            case Dir.West:
              _xRobo--;
              break;
            case Dir.Unknown:
            default:
              throw new Exception("Oops!!! was not expected!");
          }

          if (_map.ContainsKey((_xRobo, _yRobo)))
            _map[(_xRobo, _yRobo)]++;
          else
            _map.Add((_xRobo, _yRobo), 1);
        }
      }

      return _map.Count;
    }
  }
}
