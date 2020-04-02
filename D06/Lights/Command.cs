using Lights.Enum;

namespace Lights
{
  public class Command
  {
    private Instruction _instruction;
    private Point _p1;
    private Point _p2;

    public Command(Instruction i, Point p1, Point p2)
    {
      _instruction = i;
      _p1 = p1;
      _p2 = p2;
    }

    public Instruction Instruction { get => _instruction; set => _instruction = value; }
    public Point P1 { get => _p1; set => _p1 = value; }
    public Point P2 { get => _p2; set => _p2 = value; }
  }
}