using System;
using System.IO;
using System.Linq;

namespace ReindeerOlympics
{
  public static class Utils
  {
    public static Reindeer[] Parse(string path)
    {
      var file = new StreamReader(path);
      var lines = file.ReadToEnd().Trim(Environment.NewLine.ToCharArray()).Split(Environment.NewLine);

      var reindeers = new Reindeer[lines.Length];

      for (int i = 0; i < lines.Length; i++)
        reindeers[i] = CreateReindeer(lines[i]);

      return reindeers;
    }

    public static void EvaluateAndScore(Reindeer[] reindeers)
    {
      var list = reindeers.OrderByDescending(r => r.CurrentDistance).ToList();
      var distance = list[0].CurrentDistance;
      var winners = list.FindAll(r => r.CurrentDistance == distance);

      foreach (var r in winners)
        r.Points++;
    }

    private static Reindeer CreateReindeer(string line)
    {
      var s = line.Trim().Split(' ');
      return (new Reindeer(s[0], int.Parse(s[3]), int.Parse(s[6]), int.Parse(s[13])));
    }
  }
}