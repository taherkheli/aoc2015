using System;
using System.IO;

namespace Happiness
{
  public static class Utils
  {
    public static string[] Parse(string path)
    {
      var file = new StreamReader(path);
      var lines = file.ReadToEnd().Trim(Environment.NewLine.ToCharArray()).Split(Environment.NewLine);      
      return lines;
    }
  }
}