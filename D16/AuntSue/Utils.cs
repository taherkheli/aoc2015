using System;
using System.Collections.Generic;
using System.IO;

namespace AuntSue
{
  public static class Utils
  {
    public static List<Aunt> Parse(string path)
    {
      var file = new StreamReader(path);
      var lines = file.ReadToEnd().Trim(Environment.NewLine.ToCharArray()).Split(Environment.NewLine);
      var aunts = new List<Aunt>(lines.Length);

      foreach (var line in lines)
        aunts.Add(CreateAunt(line));

      return aunts;
    }

    private static Aunt CreateAunt(string line)
    {      
      var s = line.Trim().Split(' ');
      
      var id = int.Parse(s[1].Trim(':'));
      var aunt = new Aunt(id);
      
      var s1 = s[2].Trim().Trim(':');
      var v1 = int.Parse(s[3].Trim(','));
      var s2 = s[4].Trim().Trim(':');
      var v2 = int.Parse(s[5].Trim(','));
      var s3 = s[6].Trim().Trim(':');
      var v3 = int.Parse(s[7]);

      aunt.Data.Add(s1, v1);
      aunt.Data.Add(s2, v2);
      aunt.Data.Add(s3, v3);

      return aunt;
    }
  }
}