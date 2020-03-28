using Lights.Enum;

namespace Lights
{
  public class Light
  {
    private Point _point;
    private Status _status;
    
    public Light(Point p)
    {
      _point = new Point(p.X, p.Y);
    }

    public Point Point { get => _point; }
    public Status Status { get => _status; set => _status = value; }
  }
}
