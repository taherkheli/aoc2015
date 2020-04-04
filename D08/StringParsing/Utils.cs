using System;
using System.Collections.Generic;
using System.IO;

namespace StringParsing
{
  public static class Utils
  {
    public static string[] Parse(string path)
    {
      StreamReader file = new StreamReader(path);
      var lines = file.ReadToEnd().Trim(Environment.NewLine.ToCharArray()).Split(Environment.NewLine);
      return lines;
    }

    public static int GetCodeCharCount(string s)
    {
      return s.ToCharArray().Length;
    }

    public static int GetInMemoryCharCount(string s)
    {
      int result;
      int countQuote = 0;
      int countBackslash = 0;
      int countAsciHexcode = 0;

      var a = s.ToCharArray();

      for (int i = 0; i < a.Length - 1; i++)
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
            countBackslash += (occurences / 2);

            if (occurences == 2)
              i += (occurences - 1); //occurences cannot be less than 2
            else
              i += (occurences - 2); 
          }
        }
      }

      //subtract 2 as all lines are enclosed in double quotes
      result = a.Length - 2 - countQuote - countBackslash - 3 * countAsciHexcode;

      return result;
    }

    public static int CountSuccessiveOccurencesFrom(int index, string s)
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

    public static string Encode(string s)
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

    //Locate occurences of '"' and '\' in a string
    public static List<int> LocateOccurences(string s)
    {
      var result = new List<int>();
      var a = s.ToCharArray();

      for (int i = 0; i < a.Length; i++)
        if ((a[i] == '\"') || (a[i] == '\\'))
          result.Add(i);

      return result;
    }
  }
}