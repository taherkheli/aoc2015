using System.Net.NetworkInformation;

namespace aoc.D13
{
  public static class Parser
  {
    public static (List<string>, Dictionary<(string, string), int>) Parse(string path)
    {
      var guests = new HashSet<string>();
      var happiness = new Dictionary<(string, string), int>();
      var lines = File.ReadAllLines(path);

      foreach (var line in lines)
      {
        var parts = line.Split(' ', StringSplitOptions.TrimEntries);
        var guest1 = parts[0];
        var guest2 = parts[10].Trim('.');
        var sign = parts[2] == "gain" ? 1 : -1;        
        var happyValue = int.Parse(parts[3]) * sign;        
        guests.Add(guest1);
        guests.Add(guest2);
        happiness.Add((guest1, guest2), happyValue);
      }

      return (guests.ToList(), happiness);
    }
  }
}
