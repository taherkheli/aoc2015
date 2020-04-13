using LightsAgain.Enum;
using System.Collections.Generic;

namespace LightsAgain
{
  public class Light
  {
    private readonly int _r;
    private readonly int _c;
    private Status _status;
    private bool _isStuck;

    public Light(int r, int c, Status status)
    {
      _r = r;
      _c = c;
      _status = status;
      _isStuck = false;
    }

    public int R => _r;
    public int C => _c;
    public Status Status { get => _status; set => _status = value; }
    public bool IsStuck { get => _isStuck; set => _isStuck = value; }

    public void Update(List<Light> neighbors)
    {
      if (!(_isStuck))
      {
        int onCount = 0;
        foreach (var light in neighbors)
          if (light.Status == Status.On)
            onCount++;

        if (_status == Status.Off)
        {
          if (onCount == 3)
            _status = Status.On;
          else
            _status = Status.Off;
        }
        else if (_status == Status.On)
        {
          if ((onCount == 2) || (onCount == 3))
            _status = Status.On;
          else
            _status = Status.Off;
        }
      }
    }
  }
}