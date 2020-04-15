using System;
using System.IO;

namespace CookieMaking
{
  public static class Utils
  {
    public static Ingredient[] Parse(string path)
    {
      var file = new StreamReader(path);
      var lines = file.ReadToEnd().Trim().Trim(Environment.NewLine.ToCharArray()).Split(Environment.NewLine);
      var result = new Ingredient[lines.Length];

      for (int i = 0; i < result.Length; i++)      
        result[i] = Create(lines[i]);

      return result;
    }

    private static Ingredient Create(string line)
    {
      var result = new Ingredient();      
      var s = line.Trim().Split(' ');
      
      result.Capacity = int.Parse(s[2].Trim().Trim(','));
      result.Durability = int.Parse(s[4].Trim().Trim(','));
      result.Flavor = int.Parse(s[6].Trim().Trim(','));
      result.Texture = int.Parse(s[8].Trim().Trim(','));
      result.Calories = int.Parse(s[10].Trim());

      return result;
    }
  }
}