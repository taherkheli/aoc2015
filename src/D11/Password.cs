namespace aoc.D11
{
  public static class Password 
  {   
    public static string GetNextValidPassword(string s)
      {
        string result;
        var temp = s;

        while (true)
        {
          temp = Increment(temp);

          if (HasForbiddenChars(temp))
            continue;
          else
          {
            if (HasIncreasingStraight(temp))
            {
              if (HasTwoDoubles(temp))
              {
                result = temp;
                break;
              }
              else
                continue;
            }
            else
              continue;
          }
        }

        return result;
      }

    private static string Increment(string s)
    {
      char[] digits = [s[0], s[1], s[2], s[3], s[4], s[5], s[6], s[7]];

      digits[7] = NextChar(s[7]);

      if (s[7] == 'z')
        digits[6] = NextChar(s[6]);

      if ((s[6] == 'z') && (s[7] == 'z'))
        digits[5] = NextChar(s[5]);

      if ((s[5] == 'z') && (s[6] == 'z') && (s[7] == 'z'))
        digits[4] = NextChar(s[4]);

      if ((s[4] == 'z') && (s[5] == 'z') && (s[6] == 'z') && (s[7] == 'z'))
        digits[3] = NextChar(s[3]);

      if ((s[3] == 'z') && (s[4] == 'z') && (s[5] == 'z') && (s[6] == 'z') && (s[7] == 'z'))
        digits[2] = NextChar(s[2]);

      if ((s[2] == 'z') && (s[3] == 'z') && (s[4] == 'z') && (s[5] == 'z') && (s[6] == 'z') && (s[7] == 'z'))
        digits[1] = NextChar(s[1]);

      if ((s[1] == 'z') && (s[2] == 'z') && (s[3] == 'z') && (s[4] == 'z') && (s[5] == 'z') && (s[6] == 'z') && (s[7] == 'z'))
        digits[0] = NextChar(s[0]);

      return new string(digits);
    }
    
    private static char NextChar(char c)
    {
      var source = "abcdefghijklmnopqrstuvwxyz";
      int index = source.IndexOf(c);

      if (index == 25)
        index = -1; //wrap

      return source[index + 1];
    }
    
    // first requirement
    private static bool HasIncreasingStraight(string s)
    {
      bool result = false;

      if (s.Length > 2)
      {
        for (int i = 0; i < s.Length - 2; i++)
        {
          if ((s[i] == 'z') || (s[i + 1] == 'z'))  //abort          
            break;

          if ((s[i + 1] == NextChar(s[i])) && (s[i + 2] == NextChar(s[i + 1])))
          {
            result = true;
            break;
          }
        }
      }

      return result;
    }

    // second requirement
    private static bool HasForbiddenChars(string s)
    {
      foreach (var c in s)
        if ((c == 'i') || (c == 'o') || (c == 'l'))
          return true;

      return false;
    }

    private static bool HasTwoDoubles(string s)
    {
      bool result = false;
      var pairIndices = FindNonOverlappingPairs(s);

      if (pairIndices.Length > 1)
      {
        for (int i = 0; i < pairIndices.Length - 1; i++) //till second last element only
        {
          if (s[pairIndices[i]] != s[pairIndices[i + 1]])   //pairs are distant
          {
            result = true;
            break;
          }
        }
      }

      return result;
    }

    private static int[] FindNonOverlappingPairs(string s)
    {
      List<int> indices = [];
      var a = s.ToCharArray();

      for (int i = 0; i < a.Length - 1; i++)
      {
        if (a[i] == a[i + 1])
        {
          indices.Add(i);
          var occurences = CountSuccessiveOccurencesFrom(i, a[i], s);

          if (occurences % 2 == 0)   //even
            i += (occurences - 2);
          else
            i += (occurences - 1);
        }
      }

      return [.. indices];
    }

    private static int CountSuccessiveOccurencesFrom(int index, char c, string s)
    {
      int count = 0;
      var a = s.ToCharArray();

      for (int i = index; i < a.Length; i++)
      {
        if (a[i] == c)
          count++;
        else
          break;
      }

      return count;
    }
  }
}