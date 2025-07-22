namespace aoc.D06
{
  public class Grid
  {
    private int[,] _lights = new int[1000, 1000];

    public Grid()
    {
      for (int r = 0; r < 1000; r++)
        for (int c = 0; c < 1000; c++)
          _lights[r, c] = 0;
    }

    public int Execute((Cmd cmd, (int, int) point1, (int, int) point2)[] instructions, bool isPartII = false)
    {
      for (int i = 0; i < instructions.Length; i++)
        ExecuteInstruction(instructions[i], isPartII);

      return GetCount();
    }

    private void ExecuteInstruction((Cmd cmd, (int, int) point1, (int, int) point2) instruction, bool isPartII)
    {
      int r_0 = instruction.point1.Item1;
      int r_delta = instruction.point2.Item1 - r_0;
      int c_0 = instruction.point1.Item2;
      int c_delta = instruction.point2.Item2 - c_0;

      for (int r = r_0; r < r_0 + r_delta + 1; r++)
        for (int c = c_0; c < c_0 + c_delta + 1; c++)
          HandleLight(instruction, isPartII, r, c);
    }

    private void HandleLight((Cmd cmd, (int, int) point1, (int, int) point2) instruction, bool isPartII, int r, int c)
    {
      if (isPartII)
      {
        switch (instruction.cmd)
        {
          case Cmd.On:
            _lights[r, c]++;
            break;
          case Cmd.Off:
            if (_lights[r, c] != 0)
              _lights[r, c]--;
            break;
          case Cmd.Toggle:
            _lights[r, c] += 2;
            break;
          default:
            throw new Exception("Oops. Should not have happened!");
        }
      }
      else
      {
        switch (instruction.cmd)
        {
          case Cmd.On:
            _lights[r, c] = 1;
            break;
          case Cmd.Off:
            _lights[r, c] = 0;
            break;
          case Cmd.Toggle:
            _lights[r, c] = _lights[r, c] == 0 ? 1 : 0;
            break;
          default:
            throw new Exception("Oops. Should not have happened!");
        }
      }
    }

    private int GetCount()
    {
      int count = 0;

      for (int r = 0; r < 1000; r++)
        for (int c = 0; c < 1000; c++)
          if (_lights[r, c] > 0)
            count+= _lights[r, c];

      return count;
    }
  }
}
