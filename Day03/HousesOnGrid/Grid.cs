using HousesOnGrid.Enum;
using System;
using System.Collections.Generic;

namespace HousesOnGrid
{
  public class Grid
  {
    private readonly List<House> _visitedHouses;
    private House _curr;

    public Grid(int x, int y)
    {
      _curr = new House(x, y);

      _visitedHouses = new List<House>()
      {
        _curr
      };
    }

    public List<House> VisitedHouses { get => _visitedHouses; }

    public void MoveSantasBehind(Dir dir)
    {
      int xNew, yNew;

      switch (dir)
      {
        case Dir.Up:
          xNew = _curr.X;
          yNew = _curr.Y + 1;
          break;
        case Dir.Down:
          xNew = _curr.X;
          yNew = _curr.Y - 1;
          break;
        case Dir.Left:
          xNew = _curr.X - 1;
          yNew = _curr.Y;
          break;
        case Dir.Right:
          xNew = _curr.X + 1;
          yNew = _curr.Y;
          break;
        case Dir.Unknown:
        default:
          throw new Exception("Oops!!! was not expected!");
      }

      var tempHouse = _visitedHouses.Find(h => (h.X == xNew) && (h.Y == yNew));

      if (tempHouse == null)
      {
        _curr = new House(xNew, yNew);
        _visitedHouses.Add(_curr);
      }
      else
      {
        tempHouse.VisitCount++;
        _curr = tempHouse;
      }
    }
  }
}