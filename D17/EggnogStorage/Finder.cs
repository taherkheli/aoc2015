using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EggnogStorage
{
  public class Finder
  {
    private readonly List<List<Container>> _validCombos;
    private readonly List<List<Container>> _allCombos;
    private int _target;

    public Finder(int target, List<List<Container>> allCombos)
    {
      _target = target;
      _allCombos = allCombos;
      _validCombos = new List<List<Container>>();
    }

    public List<List<Container>> ValidCombos => _validCombos;

    public void Find()
    {
      foreach (var combo in _allCombos)
      {
        var candidate = new List<Container>();
        var valid = false;
        int sum = 0;
        for (int i = 0; i < combo.Count; i++)
        {
          candidate.Add(combo[i]);
          sum += combo[i].Capacity;

          if (sum < _target)
            continue;

          if (sum > _target)
            break;

          if (sum == _target)
          {
            valid = true;
            break;
          }
        }

        if (valid)
          Examine(candidate);
      }
    }

    private void Examine(List<Container> candidate)
    {
      if (_validCombos.Count == 0)
        _validCombos.Add(candidate);
      else
      {
        var isKnown = false;

        foreach (var validCombo in _validCombos)
        {
          if (AreCombosSame(validCombo, candidate)) 
          {
            isKnown = true;
            break;
          }
        }

        if (!isKnown)
          _validCombos.Add(candidate);
      }
    }

    private bool AreCombosSame(List<Container> validCombo, List<Container> candidate)
    {
      var result = true;

      if (validCombo.Count != candidate.Count)
        result = false;       
      else
      {
        foreach (var item in candidate)
        {
          var temp = validCombo.Find(c => c.Id == item.Id);

          if (temp == null)
          {
            result = false;
            break;
          }
        }
      }

      return result;
    }
  }
}
