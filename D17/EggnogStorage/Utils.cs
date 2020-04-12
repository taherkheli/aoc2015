using System;
using System.Collections.Generic;
using System.IO;

namespace EggnogStorage
{
  public static class Utils
  {
    public static List<Container> Parse(string path)
    {
      var file = new StreamReader(path);
      var lines = file.ReadToEnd().Trim(Environment.NewLine.ToCharArray()).Split(Environment.NewLine);
      var containers = new List<Container>(lines.Length);

      int i = 0;

      foreach (var line in lines)
        containers.Add(new Container(i++, int.Parse(line.Trim())));

      return containers;
    }
  }
}