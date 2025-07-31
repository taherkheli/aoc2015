using aoc.Helpers;

namespace aoc.D13
{
  public class DinnerTable((List<string>, Dictionary<(string, string), int>) input)
  {
    private readonly List<string> _guests = input.Item1;
    private readonly Dictionary<(string, string), int> _happiness = input.Item2;

    public int GetTotalChangeInHappiness(bool isPartII = false)
    {
      // make copies to preserve original state
      var guests = _guests.ToList();
      var happiness = new Dictionary<(string, string), int>(_happiness);

      if (isPartII)
      {
        guests.Add("Bilal");

        for(int i = 0; i< _guests.Count; i++)
        {
          happiness.Add(("Bilal", _guests[i]), 0);
          happiness.Add((_guests[i], "Bilal"), 0);
        }
      }

      var arrangements = Utils.GetPermutations(guests);
      var arrangementHappiness = new int[arrangements.Count];

      for (int i = 0; i < arrangements.Count; i++)
        arrangementHappiness[i] = GetArrangementHappiness(arrangements[i], happiness);

      return Utils.GetLargest(arrangementHappiness);
    }

    private static int GetArrangementHappiness(List<string> arrangement, Dictionary<(string, string), int> happiness)
    {
      int netChangeInHappiness = 0;
      string leftNeighbor;
      string rightNeighbor;

      for (int i = 0; i < arrangement.Count; i++)
      {
        var guest = arrangement[i];

        if (i == 0) // handle first
        {
          leftNeighbor = arrangement[^1];    // index operator => "the last element in the array"
          rightNeighbor = arrangement[i + 1];
        }
        else if (i == arrangement.Count - 1) // handle last
        {          
          leftNeighbor = arrangement[i - 1];
          rightNeighbor = arrangement[0];
        }
        else
        {
          leftNeighbor = arrangement[i - 1];
          rightNeighbor = arrangement[i + 1];
        }

        netChangeInHappiness += happiness[(guest, leftNeighbor)] + happiness[(guest, rightNeighbor)];
      }

      return netChangeInHappiness;
    }
  }
}