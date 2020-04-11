using System.Collections.Generic;

namespace AuntSue
{
  public class Aunt
  {
    private readonly int _id;
    private Dictionary<string, int> _data;

    public Aunt(int id)
    {
      _id = id;
      _data = new Dictionary<string, int>();
    }

    public Dictionary<string, int> Data { get => _data; set => _data = value; }

    public int Id => _id;

    public bool MatcheDescription(Dictionary<string, int> source)
    {
      foreach (KeyValuePair<string, int> entry in _data)
      {
        if (source[entry.Key] != entry.Value)
          return false;        
      }

      return true;
    }
  }
}