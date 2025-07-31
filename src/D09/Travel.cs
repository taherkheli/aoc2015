using aoc.Helpers;

namespace aoc.D09
{
  public class Travel((List<string>, Dictionary<(string, string), int>) input)
  {
    private readonly List<string> _cities = input.Item1;
    private readonly Dictionary<(string, string), int> _distances = input.Item2;

    public int GetDistance(bool isPartII = false)
    {
      var routes = Utils.GetPermutations(_cities);
      var routeDistances = new int[routes.Count];

      for (int i = 0; i < routes.Count; i++)
        routeDistances[i] = GetRouteDistance(routes[i]);

      return isPartII ? Utils.GetLargest(routeDistances) : Utils.GetSmallest(routeDistances);
    }

    private int GetRouteDistance(List<string> route)
    {
      var sum = 0;

      for (int i = 0; i < route.Count - 1; i++)
        sum += _distances[(route[i], route[i + 1])];

      return sum; 
    }
  }
}