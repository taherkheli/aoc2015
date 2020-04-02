using Lights.Enum;
using System;

namespace Lights
{
  public class Grid
  {
    private readonly int _r;
    private readonly int _c;
    private readonly Light[,] _lights;

    public Grid(int rows, int cols)
    {
      _r = rows;
      _c = cols;

      _lights = new Light[_r, _c];

      for (int r = 0; r < _r; r++)
        for (int c = 0; c < _c; c++)
          _lights[r, c] = new Light(new Point(r, c));
    }

    public int LitCount { get => GetLitCount(); }

    public int TotalBrightness { get => GetTotalBrightness(); }

    public void Execute(Command cmd)
    {
      int r_start = cmd.P1.Y;
      int r_end = r_start + cmd.P2.Y - cmd.P1.Y + 1;
      int c_start = cmd.P1.X;
      int c_end = c_start + cmd.P2.X - cmd.P1.X + 1;

      for (int r = r_start; r < r_end; r++)
        for (int c = c_start; c < c_end; c++)
        {
          var temp = _lights[r, c];

          switch (cmd.Instruction)
          {
            case Instruction.On:
              temp.Status = Status.On;
              temp.Brightness++;
              break;

            case Instruction.Off:
              temp.Status = Status.Off;
              if (temp.Brightness > 0)
                temp.Brightness--;
              break;

            case Instruction.Toggle:
              temp.Brightness += 2;

              if (temp.Status == Status.Off)
                temp.Status = Status.On;
              else
                temp.Status = Status.Off;
              break;
            
            case Instruction.Unknown:
            default:
              throw new Exception("Unknown instruction!");
          }
        }
    }

    private int GetLitCount()
    {
      int count = 0;

      for (int r = 0; r < _r; r++)
        for (int c = 0; c < _c; c++)
          if (_lights[r, c].Status == Status.On)
            count++;

      return count;
    }
    
    private int GetTotalBrightness()
    {
      int brightness = 0;

      for (int r = 0; r < _r; r++)
        for (int c = 0; c < _c; c++)
          brightness+= _lights[r,c].Brightness;

      return brightness;
    }
  }
}