using LightsAgain.Enum;
using System;
using System.Collections.Generic;

namespace LightsAgain
{
  public class Grid
  {
    private readonly int[] _cfg;
    private Light[] _lights;
    private Light[] _currState;

    public Grid(int[] cfg, bool isPartII = false)
    {
      _cfg = cfg;
      Initialize(isPartII);
    }

    public Light[] CurrState { get => _currState; set => _currState = value; }

    private void Initialize(bool isPartII)
    {
      var n = (int)Math.Sqrt(_cfg.Length);
      _lights = new Light[n * n];
      _currState = new Light[n * n];

      for (int r = 0; r < n; r++)
        for (int c = 0; c < n; c++)
        {
          if (_cfg[r * n + c] == 1)
            _lights[r * n + c] = new Light(r, c, Status.On);
          else
            _lights[r * n + c] = new Light(r, c, Status.Off);
        }

      if (isPartII)
        HandleStuckCorners();

      for (int i = 0; i < _lights.Length; i++)
        _currState[i] = new Light(_lights[i].R, _lights[i].C, _lights[i].Status);
    }

    public void GoToNextState()
    {
      foreach (var light in _lights)
        light.Update(GetNeighbours(light));

      for (int i = 0; i < _lights.Length; i++)
        _currState[i] = new Light(_lights[i].R, _lights[i].C, _lights[i].Status);
    }

    private List<Light> GetNeighbours(Light light)
    {
      var result = new List<Light>();
      int size = (int)Math.Sqrt(_lights.Length);
      var r = light.R;
      var c = light.C;

      if (IsNotOutOfBounds(r, c - 1))
        result.Add(_currState[r * size + (c - 1)]);

      if (IsNotOutOfBounds(r - 1, c - 1))
        result.Add(_currState[(r * size - size) + (c - 1)]);

      if (IsNotOutOfBounds(r - 1, c))
        result.Add(_currState[(r * size - size) + c]);

      if (IsNotOutOfBounds(r - 1, c + 1))
        result.Add(_currState[(r * size - size) + (c + 1)]);

      if (IsNotOutOfBounds(r, c + 1))
        result.Add(_currState[r * size + (c + 1)]);

      if (IsNotOutOfBounds(r + 1, c + 1))
        result.Add(_currState[(r * size) + size + (c + 1)]);

      if (IsNotOutOfBounds(r + 1, c))
        result.Add(_currState[(r * size) + size + c]);

      if (IsNotOutOfBounds(r + 1, c - 1))
        result.Add(_currState[(r * size) + size + (c - 1)]);

      return result;
    }

    private bool IsNotOutOfBounds(int r, int c)
    {
      int size = (int)Math.Sqrt(_lights.Length);

      if ((r < 0) || (c < 0) || (r > (size - 1)) || (c > (size - 1)))
        return false;

      return true;
    }

    private void HandleStuckCorners()
    {
      int size = (int)Math.Sqrt(_lights.Length);

      _lights[0].Status = Status.On;
      _lights[0].IsStuck = true;
      _lights[size - 1].Status = Status.On;
      _lights[size - 1].IsStuck = true;
      _lights[^1].Status = Status.On;
      _lights[^1].IsStuck = true;
      _lights[size * (size - 1)].Status = Status.On;
      _lights[size * (size - 1)].IsStuck = true;
    }
  }
}