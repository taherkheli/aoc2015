using System;
using System.Collections.Generic;

namespace LightsAgain
{
  public class Grid
  {
    private readonly Light[] _lights;
    private readonly Light[] _currentCnfig;

    public Grid(Light[] lights)
    {
      _lights = lights;
      _currentCnfig = new Light[lights.Length];
      Array.Copy(lights, _currentCnfig, lights.Length);
    }

    public Light[] Lights => _lights;

    public void Increment()
    {
      //step1: evaluate next state by applying current configuration
      foreach (var light in _lights)      
        light.CalculateNextState(GetNeighbours(light));

      //step2: go to next state "simulatneously" for all lights
      foreach (var light in _lights)
        light.Update();
     
      Array.Copy(_lights, _currentCnfig, _lights.Length);
    }

    private List<Light> GetNeighbours(Light light)
    {
      var result = new List<Light>();
      int size = (int)Math.Sqrt(_lights.Length);
      var r = light.R;
      var c = light.C;

      if (IsNotOutOfBounds(r, c - 1))
        result.Add(_currentCnfig[r * size + (c - 1)]);

      if (IsNotOutOfBounds(r - 1, c - 1))
        result.Add(_currentCnfig[(r * size - size) + (c - 1)]);

      if (IsNotOutOfBounds(r - 1, c))
        result.Add(_currentCnfig[(r * size - size) + c]);

      if (IsNotOutOfBounds(r - 1, c + 1))
        result.Add(_currentCnfig[(r * size - size) + (c + 1)]);

      if (IsNotOutOfBounds(r, c + 1))
        result.Add(_currentCnfig[r * size + (c + 1)]);

      if (IsNotOutOfBounds(r + 1, c + 1))
        result.Add(_currentCnfig[(r * size) + size + (c + 1)]);

      if (IsNotOutOfBounds(r + 1, c))
        result.Add(_currentCnfig[(r * size) + size + c]);

      if (IsNotOutOfBounds(r + 1, c - 1))
        result.Add(_currentCnfig[(r * size) + size + (c - 1)]);

      return result;
    }
    
    private bool IsNotOutOfBounds(int r, int c)
    {
      int size = (int)Math.Sqrt(_lights.Length);

      if ((r < 0) || (c < 0) || (r > (size - 1)) || (c > (size - 1)))
        return false;

      return true;
    }
  }
}