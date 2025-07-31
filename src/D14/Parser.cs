namespace aoc.D14
{
  public static class Parser
  {
    public static Reindeer[] Parse(string path)
    {
      var file = new StreamReader(path);
      var lines = File.ReadAllLines(path);
      var reindeers = new Reindeer[lines.Length];

      for (int i = 0; i < lines.Length; i++)
        reindeers[i] = CreateReindeer(lines[i]);

      return reindeers;
    }

    private static Reindeer CreateReindeer(string line)
    {
      var s = line.Split(' ', StringSplitOptions.TrimEntries);
      return (new Reindeer(s[0], int.Parse(s[3]), int.Parse(s[6]), int.Parse(s[13])));
    }
  }
}
