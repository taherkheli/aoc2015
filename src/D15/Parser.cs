namespace aoc.D15
{
  public static class Parser
  {
    public static Ingredient[] Parse(string path)
    {
      var lines = File.ReadAllLines(path);
      var result = new Ingredient[lines.Length];

      for (int i = 0; i < result.Length; i++)
        result[i] = GetIngredient(lines[i]);

      return result;
    }

    private static Ingredient GetIngredient(string line)
    {
      var result = new Ingredient();
      var s = line.Split(' ', StringSplitOptions.TrimEntries);
      result.Capacity = int.Parse(s[2].TrimEnd(','));
      result.Durability = int.Parse(s[4].Trim().Trim(','));
      result.Flavor = int.Parse(s[6].Trim().Trim(','));
      result.Texture = int.Parse(s[8].Trim().Trim(','));
      result.Calories = int.Parse(s[10].TrimEnd());
      return result;
    }
  }
}
