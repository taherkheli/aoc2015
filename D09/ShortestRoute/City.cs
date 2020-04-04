using Lib;
using System.Collections.Generic;
using System.Linq;

namespace ShortestRoute
{
  public class City
  {
    private readonly string _name;

    public City(string name)
    {
      _name = name;
    }

    public string Name => _name;

    public int ShortestRouteDistance(World w)
    {
      int shortest = int.MaxValue;
      
      var cities = new List<City>(w.Cities);

      //detach current city before calculating permutations
      cities.Remove(this);
      
      var permutations = cities.Permute();

      var routes = new List<List<City>>();

      foreach (var p in permutations)
        routes.Add(p.ToList());

      //re-insert current city 
      foreach (var route in routes)
        route.Insert(0, this);

      foreach (var route in routes)
      {
        var d = GetDistance(route, w);

        if (d < shortest)
          shortest = d;
      }

      return shortest;
    }

    private int GetDistance(List<City> route, World w)
    {
      int result = 0;

      for (int i = 0; i < route.Count - 1; i++)
        result += w.Distances[route[i].Name][route[i + 1].Name];
      
      return result;
    }
  }
}