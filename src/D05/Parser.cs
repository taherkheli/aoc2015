using System;
using System.IO;

namespace aoc.D05
{
  public class Parser
  {
    public static string[] Parse(string path)
    {
      StreamReader file = new StreamReader(path);
      var text = file.ReadToEnd().Trim(Environment.NewLine.ToCharArray());
      return text.Split(Environment.NewLine);
    }
  }
}
