namespace aoc.D09
{
  public static class Parser
  {
    public static (List<string>, Dictionary<(string, string), int>) Parse(string path)
    {
      var cities = new HashSet<string>();
      var distances = new Dictionary<(string, string), int>();
      var lines = File.ReadAllLines(path);

      foreach (var line in lines)
      {
        var parts = line.Split(' ', StringSplitOptions.TrimEntries);
        var city1 = parts[0];
        var city2 = parts[2];
        var distance = int.Parse(parts[4]);        
        cities.Add(city1);
        cities.Add(city2);
        distances.Add((city1, city2), distance);
        distances.Add((city2, city1), distance);
      }

      return (cities.ToList<string>(), distances);
    }
  }
}
