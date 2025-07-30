namespace aoc.D08
{
  public class StringParser
  {
    private string[] _strings;
    
    public StringParser(string[] strings)
    {
      _strings = strings;        
    }

    public int Solve(bool isPartII = false)
    {
      int sumA = 0;
      int sumB = 0;
      int sumC = 0;

      foreach (var s in _strings)
      {
        int x = s.Count();   //chars in code
        sumA += x;
        int y = GetInMemoryCharCount(s);
        sumB += y;

        var encodedString = Encode(s);
        int z = encodedString.Count();
        sumC += z;
      }

      return isPartII ? sumC - sumA : sumA - sumB;
    }

    private int GetInMemoryCharCount(string s)
    {
      int result;
      int countQuote = 0;
      int countBackSlash = 0;
      int countAsciHexcode = 0;

      var a = s.ToCharArray();

      for (int i = 0; i < s.Length - 1; i++)
      {
        if (a[i] == '\\')
        {
          var occurences = CountSuccessiveOccurencesFrom(i, s);

          if (occurences % 2 != 0)   //odd
          {
            if (a[i + 1] == '\"')
              countQuote++;

            if (a[i + 1] == 'x')
              countAsciHexcode++;
          }

          if (a[i + 1] == '\\')
          {
            occurences = CountSuccessiveOccurencesFrom(i, s);
            countBackSlash += (occurences / 2);

            if (occurences == 2)
              i += (occurences - 1); //occurences cannot be less than 2
            else
              i += (occurences - 2);
          }
        }
      }

      //subtract 2 as all lines are enclosed in double quotes
      result = a.Length - 2 - countQuote - countBackSlash - 3 * countAsciHexcode;

      return result;
    }

    private int CountSuccessiveOccurencesFrom(int index, string s)
    {
      int count = 0;
      var a = s.ToCharArray();

      for (int i = index; i < a.Length; i++)
      {
        if (a[i] == '\\')
          count++;
        else
          break;
      }

      return count;
    }

    private string Encode(string s)
    {
      var a = s.ToCharArray();
      List<char> l = new List<char>(a);

      var indices = LocateOccurences(s);

      for (int i = 0; i < indices.Count; i++)
      {
        l.Insert(indices[i], '\\');

        for (int j = i + 1; j < indices.Count; j++)
          indices[j]++;
      }

      //enclose in quotes
      l.Insert(0, '\"');
      l.Insert(l.Count - 1, '\"');

      s = new string(l.ToArray());
      return s;
    }

    //Locate indices of '"' and '\' in a string
    private List<int> LocateOccurences(string s)
    {
      var result = new List<int>();

      for (int i = 0; i < s.Length; i++)
        if ((s[i] == '\"') || (s[i] == '\\'))
          result.Add(i);

      return result;
    }
  }
}
