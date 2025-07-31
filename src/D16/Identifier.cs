namespace aoc.D16
{
  public class Identifier(Aunt[] aunts)
  {
    private readonly Aunt[] _aunts = aunts;

    public int? GetSenderAuntId(Dictionary<string, int> senderData, bool isPartII = false)
    {
      foreach (var aunt in _aunts)
      {
        bool isMatch = isPartII ? aunt.MatchesPartII(senderData) : aunt.Matches(senderData);
        if (isMatch)
          return aunt.Id; // returns first match                            
      }

      return null;
    }
  }
}
