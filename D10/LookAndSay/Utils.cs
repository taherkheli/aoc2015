using System.Collections.Generic;

namespace LookAndSay
{
  public class Utils
  {
    //fragment a string into repetitive string e.g. "2222" or "111111" 
    public static string[] GetFragments(string s)
    {
      string[] result;
      var temp = new List<List<char>>() { };

      var a = s.ToCharArray();

      int index = 0;
      temp.Add(new List<char>());

      for (int i = 0; i < a.Length; i++)
      {
        if (a.Length == 1)
        {
          temp[index].Add(a[i]);
          break;
        }
        else
        {
          if (i == a.Length - 1)
            temp[index].Add(a[i]);
          else
          {
            temp[index].Add(a[i]);

            if (a[i] != a[i + 1])
            {
              index++;
              temp.Add(new List<char>());
            }
          }
        }
      }

      result = new string[temp.Count];

      for (int i = 0; i < temp.Count; i++)
        result[i] = new string(temp[i].ToArray());

      return result;
    }

    //Encode a repetitive string e.g. "2222" or "111111" 
    public static string Encode(string s)
    {
      string result = string.Empty;
      var a = s.ToCharArray();

      if (a.Length > 0)
      {
        for (int i = 0; i < a.Length - 1; i++)
          if (a[i] != a[i + 1])
            return null;

        result = a.Length.ToString() + a[0];
      }

      return result;
    }
  }
}
