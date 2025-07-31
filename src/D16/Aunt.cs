namespace aoc.D16
{
  public class Aunt(int id)
  {
    private readonly int _id = id;
    private Dictionary<string, int> _data = [];

    public Dictionary<string, int> Data { get => _data; set => _data = value; }

    public int Id => _id;

    public bool Matches(Dictionary<string, int> source)
    {
      foreach (var entry in _data)
        if (source[entry.Key] != entry.Value)
          return false;      

      return true;
    }

    public bool MatchesPartII(Dictionary<string, int> source)
    {
      foreach (var entry in _data)
      {
        switch (entry.Key)
        {
          case "cats":
          case "trees":
            if (entry.Value <= source[entry.Key])
              return false;            
            break;
          case "pomeranians":
          case "goldfish":
            if (entry.Value >= source[entry.Key])
              return false;
            break;
          case "children":
          case "samoyeds":
          case "akitas":
          case "vizslas":
          case "cars":
          case "perfumes":
            if (source[entry.Key] != entry.Value)
              return false;
            break;            
        }
      }

      return true;
    }
  }
}
