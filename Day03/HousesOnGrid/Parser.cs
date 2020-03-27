using HousesOnGrid.Enum;
using System;
using System.IO;

namespace HousesOnGrid
{
  public static class Parser
  {
    public static Dir[] Parse(string path)
    {
      Dir[] result;
      StreamReader file = new StreamReader(path);
      string text = file.ReadToEnd();
      text = text.Trim(Environment.NewLine.ToCharArray());
      result = new Dir[text.Length];

      for (int i = 0; i < result.Length; i++)
        result[i] = Create(text[i]);

      return result;
    }

    private static Dir Create(char s)
    {
      var result = s switch
      {
        '<' => Dir.Left,
        '>' => Dir.Right,
        '^' => Dir.Up,
        'v' => Dir.Down,
        _ => Dir.Unknown,
      };

      return result;
    }
  }
}