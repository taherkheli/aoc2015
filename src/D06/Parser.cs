namespace aoc.D06
{
  public static class Parser
  {
    public static (Cmd cmd, (int, int) point1, (int, int) point2)[] Parse(string path)
    {
      var text = File.ReadAllLines(path);
      var result = new (Cmd cmd, (int, int) point1, (int, int) point2)[text.Length];

      for (int i = 0; i < text.Length; i++)
        result[i] = ParseLine(text[i]);

      return result;
    }

    private static (Cmd cmd, (int, int) point1, (int, int) point2) ParseLine(string line)
    {
      Cmd cmd = new Cmd();

      cmd = new Cmd();
      int x1, y1, x2, y2;
      string[] p1, p2;
      var parts = line.Split(' ');

      if (parts.Length == 4)
      {
        cmd = Cmd.Toggle;
        p1 = parts[1].Split(',');
        p2 = parts[3].Split(",");
      }
      else
      {
        cmd = parts[1] == "on" ? Cmd.On : Cmd.Off;
        p1 = parts[2].Split(',');
        p2 = parts[4].Split(",");
      }

      x1 = int.Parse(p1[0]);
      y1 = int.Parse(p1[1]);
      x2 = int.Parse(p2[0]);
      y2 = int.Parse(p2[1]);

      return (cmd, (x1, y1), (x2, y2));
    }
  }
}
