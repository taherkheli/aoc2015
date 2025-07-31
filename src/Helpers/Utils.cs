namespace aoc.Helpers
{
  public static class Utils
  {
    public static int GetSmallest(int[] nums)
    {
      var smallest = nums[0];

      for (int i = 1; i < nums.Length; i++)
        if (nums[i] < smallest)
          smallest = nums[i];

      return smallest;
    }

    public static int GetLargest(int[] nums)
    {
      var largest = nums[0];

      for (int i = 1; i < nums.Length; i++)
        if (nums[i] > largest)
          largest = nums[i];

      return largest;
    }

    public static List<List<T>> GetPermutations<T>(List<T> elements)
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
