namespace aoc.D05
{
  public class NiceStrings
  {
    int _niceCount;
    string[] _strings;

    public NiceStrings(string[] strings)
    {
      _niceCount = 0;
      _strings = strings;
    }

    public int PartI()
    {
      _niceCount = 0;

      foreach (var s in _strings)
      {
        if (HasDisallowedChars(s))
          continue;

        if (!HasThreeVowels(s))
          continue;

        if (!HasOneDouble(s))
          continue;

        _niceCount++;
      }

      return _niceCount;
    }

    public int PartII()
    {
      _niceCount = 0;

      foreach (var s in _strings)
      {
        if (!HasSeparatedDouble(s))
          continue;

        if (!HasTwoNonOverlappingPairs(s))
          continue;

        _niceCount++;
      }

      return _niceCount;
    }

    private bool HasDisallowedChars(string s)
    {
      bool found = false;

      var disallowedSubstrings = new string[] { "ab", "cd", "pq", "xy" };

      foreach (var substring in disallowedSubstrings)
      {
        if (s.Contains(substring))
        {
          found = true;
          break;
        }
      }

      return found;
    }

    private bool HasThreeVowels(string s)
    {
      bool found = false;
      var charArr = s.ToCharArray();
      var vowelCount = 0;

      var vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

      foreach (var vowel in vowels)
      {
        for (int i = 0; i < charArr.Length; i++)
          if (charArr[i] == vowel)
            vowelCount++;

        if (vowelCount > 2)
        {
          found = true;
          break;
        }
      }

      return found;
    }

    private bool HasOneDouble(string s)
    {
      bool found = false;
      var charArr = s.ToCharArray();

      for (int i = 0; i < charArr.Length - 1; i++)
      {
        if (charArr[i] == charArr[i + 1])
        {
          found = true;
          break;
        }
      }

      return found;
    }

    private bool HasTwoNonOverlappingPairs(string s)
    {
      bool found = false;
      var charArr = s.ToCharArray();
      int count = 0;

      for (int i = 0; i < charArr.Length - 1; i++)
      {
        count = 1;

        for (int j = i + 2; j < charArr.Length - 1; j++)
        {
          if ((charArr[i] == charArr[j]) && (charArr[i + 1] == charArr[j + 1]))
            count++;
        }

        if (count > 1)
        {
          found = true;
          break;
        }
      }

      return found;
    }

    private bool HasSeparatedDouble(string s)
    {
      bool found = false;
      var charArr = s.ToCharArray();

      for (int i = 0; i < charArr.Length - 2; i++)
      {
        if (charArr[i] == charArr[i + 2])
        {
          found = true;
          break;
        }
      }

      return found;
    }

  }
}
