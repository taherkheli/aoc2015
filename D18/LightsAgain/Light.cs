using LightsAgain.Enum;
using System.Collections.Generic;

namespace LightsAgain
{
  public class Light
  {
    private readonly int _r;
    private readonly int _c;
    private Status _status;
    private Status _nextStatus;

    public Light(int r, int c, Status status)
    {
      _r = r;
      _c = c;
      _status = status;
      _nextStatus = Status.Unknown;
    }

    public Status Status { get => _status; set => _status = value; }
    public int R => _r;
    public int C => _c;
   
    public void CalculateNextState(List<Light> neighbors)
    {
      int onCount = 0;
      foreach (var light in neighbors)
        if (light.Status == Status.On)
          onCount++;

      if (_status == Status.Off)
      {
        if (onCount == 3)
          _nextStatus = Status.On;
        else
          _nextStatus = Status.Off;
      }
      else if (_status == Status.On)
      {
        if ((onCount == 2) || (onCount == 3))
          _nextStatus = Status.On;
        else
          _nextStatus = Status.Off;
      }
    }

    public void Update()
    {
      _status = _nextStatus;
      _nextStatus = Status.Off;
    }
  }
}