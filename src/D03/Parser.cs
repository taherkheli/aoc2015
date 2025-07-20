namespace aoc.D03
{
  public static class Parser
  {
    public static Dir[] Parse(string path)
    {
      Dir[] result;
      var text = File.ReadAllLines(path)[0].Trim();
      result = new Dir[text.Length];

      for (int i = 0; i < result.Length; i++)
        result[i] = GetDirection(text[i]);

      return result;
    }

    private static Dir GetDirection(char s)
    {
      var result = s switch
      {
        '<' => Dir.West,
        '>' => Dir.East,
        '^' => Dir.North,
        'v' => Dir.South,
        _ => Dir.Unknown,
      };

      return result;
    }
  }
}
