using FirstComputer.Enum;
using System;
using System.Collections.Generic;
using System.IO;

namespace FirstComputer
{
  public static class Utils
  {

    public static Instruction[] Parse(string path)
    {
      var file = new StreamReader(path);
      var lines = file.ReadToEnd().Trim(Environment.NewLine.ToCharArray()).Split(Environment.NewLine);
      var result = new Instruction[lines.Length + 1];

      for (int i = 0; i < result.Length - 1; i++)
        result[i] = Create(lines[i]);

      result[^1]= (new Instruction(OpCode.Exit));

      return result;
    }

    private static Instruction Create(string line)
    {
      var result = new Instruction();

      var s = line.Trim(Environment.NewLine.ToCharArray()).Split(' ');

      result.OpCode = (s[0]) switch
      {
        "hlf" => OpCode.Half,
        "tpl" => OpCode.Triple,
        "inc" => OpCode.Increment,
        "jmp" => OpCode.Jump,
        "jie" => OpCode.JumpIfEven,
        "jio" => OpCode.JumpIfOne,
        _ => OpCode.Unknown,
      };

      result.Op1 = s[1].Trim().Trim(',');

      if (s.Length > 2)
        result.Op2 = s[2].Trim();

      return result;
    }

  }
}
