using System;
using System.IO;

namespace NiceStrings
{
  public static class Utils
  {
    internal static string[] Parse(string path)
    {
      StreamReader file = new StreamReader(path);
      var text = file.ReadToEnd().Trim(Environment.NewLine.ToCharArray());
      return text.Split(Environment.NewLine);
    }

    internal static bool HasDisallowedChars(string s)
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

    internal static bool HasThreeVowels(string s)
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

    internal static bool HasOneDouble(string s)
    {
      bool found = false;
      var charArr = s.ToCharArray();

      for (int i = 0; i < charArr.Length - 1; i++)
      {
        for (int j = 1; j < 2; j++)
          if (charArr[i] == charArr[i+j])
            found = true;

        if (found)
          break;
      }

      return found;
    }
  }
}
