using Lights.Enum;
using System;
using System.IO;

namespace Lights
{
  public static class Utils
  {
    public static Command[] Parse(string path)
    {
      StreamReader file = new StreamReader(path);
      var lines = file.ReadToEnd().Trim(Environment.NewLine.ToCharArray()).Split(Environment.NewLine);

      return Parse(lines);
    }

    public static Command[] Parse(string[] lines)
    {
      var result = new Command[lines.Length];

      for (int i = 0; i < result.Length; i++)
        result[i] = Create(lines[i]);

      return result;
    }

    private static Command Create(string s)
    {
      Point p1;
      Point p2;
      Instruction i;

      var strings = s.Split("through");
      var s0 = strings[0].Trim().Split(' ');

      //p1 & instruction
      if (s0.Length == 2)
      {
        var temp = s0[1].Trim().Trim().Split(',');
        p1 = new Point(int.Parse(temp[0]), int.Parse(temp[1]));
        i = Instruction.Toggle;
      }
      else 
      {
        var temp = s0[2].Trim().Trim().Split(',');
        p1 = new Point(int.Parse(temp[0]), int.Parse(temp[1]));

        if (s0[1] == "on")
          i = Instruction.On;
        else
          i = Instruction.Off;
      }  

      //p2
      var s1 = strings[1].Trim().Trim(Environment.NewLine.ToCharArray()).Split(',');
      p2 = new Point(int.Parse(s1[0]), int.Parse(s1[1]));

      //cmd
      Command result = new Command(i, p1, p2);
      return result;      
    }
  }
}