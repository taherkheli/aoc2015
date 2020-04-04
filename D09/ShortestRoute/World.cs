using System;
using System.Collections.Generic;
using System.Text;

namespace ShortestRoute
{
  public class World
  {
    private List<City> _cities;
    private Dictionary<string, Dictionary<string, int>> _distances;

    public World(string[] lines)
    {
      _cities = new List<City>();
      _distances = new Dictionary<string, Dictionary<string, int>>();
      Initialize(lines);
    }

    public List<City> Cities { get => _cities; set => _cities = value; }
    public Dictionary<string, Dictionary<string, int>> Distances { get => _distances; set => _distances = value; }

    private void Initialize(string[] lines)
    {
      foreach (var s in lines)
      {
        //distance
        var strings = s.Split("=");
        var distance = int.Parse(strings[1].Trim().Trim(Environment.NewLine.ToCharArray()));

        //cities
        var s_0 = strings[0].Trim().Split("to");
        var c1 = s_0[0].Trim();
        var c2 = s_0[1].Trim();

        var temp = _cities.Find(c => c.Name == c1);
        if (temp == null)
        {
          _cities.Add(new City(c1));
          _distances.Add(c1, new Dictionary<string, int>());
          _distances[c1].Add(c2, distance);
        }
        else
          _distances[temp.Name].Add(c2, distance);

        temp = _cities.Find(c => c.Name == c2);
        if (temp == null)
        {
          _cities.Add(new City(c2));
          _distances.Add(c2, new Dictionary<string, int>());
          _distances[c2].Add(c1, distance);
        }
        else
          _distances[temp.Name].Add(c1, distance);
      }
    }
  }
}
