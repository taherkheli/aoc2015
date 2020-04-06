using System;
using System.IO;

namespace ShortestRoute
{
  public class Utils
  {
    public static string[] Parse(string path)
    {
      StreamReader file = new StreamReader(path);
      var lines = file.ReadToEnd().Trim(Environment.NewLine.ToCharArray()).Split(Environment.NewLine);
      return lines;
    }
  }
}
