using Lights.Enum;

namespace Lights
{
  public class Light
  {
    private Point _point;
    private Status _status;
    private int _brightness;
    
    public Light(Point p)
    {
      _point = new Point(p.X, p.Y);
      _status = Status.Off;
      _brightness = 0;
    }

    public Point Point { get => _point; }
    public Status Status { get => _status; set => _status = value; }
    public int Brightness { get => _brightness; set => _brightness = value; }
  }
}
