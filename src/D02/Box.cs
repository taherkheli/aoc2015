using System;

namespace aoc.D02
{
  public class Box
  {
    private readonly int _l;
    private readonly int _w;
    private readonly int _h;
    private readonly int _v;
    private readonly int _area;

    public Box(int l, int w, int h)
    {
      _l = l;
      _w = w;
      _h = h;
      _v = l * w * h;
      _area = (2 * l * w) + (2 * w * h) + (2 * h * l);
    }

    public int GetWrapperPaperNeeded()
    {
      var smallestArea = Math.Min(Math.Min(_l * _w, _w * _h), _h * _l);

      return (_area + smallestArea);
    }

    public int GetRibbonNeeded()
    {
      var arr = new int[3] { _l, _w, _h };
      Array.Sort(arr);

      var p = (2 * arr[0]) + (2 * arr[1]);

      return (p + _v);
    }
  }
}
