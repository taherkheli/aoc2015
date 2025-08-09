namespace aoc.D23
{
  public static class Parser
  {
    public static Instruction[] Parse(string path)
    {
      var lines = File.ReadAllLines(path);
      var instructions = new Instruction[lines.Length + 1]; // i extra for appending exit instruction at the end

      for (int i = 0; i < lines.Length; i++)
        instructions[i] = ExtractInstruction(lines[i]);

      instructions[^1] = new Instruction(OpCode.Exit);

      return instructions;
    }

    private static Instruction ExtractInstruction(string line)
    {
      var instruction = new Instruction();
      var s = line.Split(' ', StringSplitOptions.TrimEntries);

      instruction.OpCode = (s[0]) switch
      {
        "hlf" => OpCode.Half,
        "tpl" => OpCode.Triple,
        "inc" => OpCode.Increment,
        "jmp" => OpCode.Jump,
        "jie" => OpCode.JumpIfEven,
        "jio" => OpCode.JumpIfOne,
        _ => OpCode.Unknown,
      };

      instruction.Op1 = s[1].Trim(',');

      if (s.Length > 2)
        instruction.Op2 = s[2];

      return instruction;
    }  
  }
}