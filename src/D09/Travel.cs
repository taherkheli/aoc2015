namespace aoc.D09
{
  public class Travel((List<string>, Dictionary<(string, string), int>) input)
  {
    private readonly List<string> _cities = input.Item1;
    private readonly Dictionary<(string, string), int> _distances = input.Item2;

    public int GetDistance(bool isPartII = false)
    {
      var routes = GetPermutations(_cities);
      var routeDistances = new int[routes.Count];

      for (int i = 0; i < routes.Count; i++)
        routeDistances[i] = GetRouteDistance(routes[i]);

      return isPartII ? GetLargest(routeDistances) : GetSmallest(routeDistances);
    }

    private static int GetSmallest(int[] nums)
    {
      var smallest = nums[0];

      for (int i = 1; i < nums.Length; i++)
        if (nums[i] < smallest)
          smallest = nums[i];

      return smallest;
    }

    private static int GetLargest(int[] nums)
    {
      var largest = nums[0];

      for (int i = 1; i < nums.Length; i++)
        if (nums[i] > largest)
          largest = nums[i];

      return largest;
    }

    private int GetRouteDistance(List<string> route)
    {
      var sum = 0;

      for (int i = 0; i < route.Count - 1; i++)
        sum += _distances[(route[i], route[i + 1])];

      return sum; 
    }

    private static List<List<T>> GetPermutations<T>(List<T> elements)
    {
      var result = new List<List<T>>();
      Permute(elements, 0, elements.Count - 1, result);
      return result;
    }

    private static void Permute<T>(List<T> elements, int start, int end, List<List<T>> result)
    {
      if (start == end)
        result.Add([.. elements]);      
      else
      {
        for (int i = start; i <= end; i++)
        {
          Swap(elements, start, i);
          Permute(elements, start + 1, end, result);
          Swap(elements, start, i); // backtrack
        }
      }
    }

    private static void Swap<T>(List<T> list, int a, int b)
    {
      (list[b], list[a]) = (list[a], list[b]);
    }
  }
}