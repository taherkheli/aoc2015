namespace aoc.D16
{
  public static class Parser
  {
    public static Aunt[] Parse(string path)
    {
      var lines = File.ReadAllLines(path);
      var aunts = new Aunt[lines.Length];

      for (int i = 0; i < lines.Length; i++)
        aunts[i] = CreateAunt(lines[i]);

      return aunts;
    }

    private static Aunt CreateAunt(string line)
    {
      var s = line.Split(' ', StringSplitOptions.TrimEntries);
      var id = int.Parse(s[1].TrimEnd(':'));
      var aunt = new Aunt(id);

      var k1 = s[2].TrimEnd(':');
      var v1 = int.Parse(s[3].TrimEnd(','));
      var k2 = s[4].TrimEnd(':');
      var v2 = int.Parse(s[5].TrimEnd(','));
      var k3 = s[6].TrimEnd(':');
      var v3 = int.Parse(s[7].TrimEnd(','));

      aunt.Data.Add(k1, v1);
      aunt.Data.Add(k2, v2);
      aunt.Data.Add(k3, v3);

      return aunt;
    }
  }
}
