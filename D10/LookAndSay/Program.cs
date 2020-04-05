using System;
using System.Text;

namespace LookAndSay
{
  class Program
  {
    static void Main()
    {
      int count = 40;
      var s = "1321131112";
      
      Console.WriteLine("\nPartI: The length of the result after {0} ops: {1}", count, GetLength(count, s));

      count = 50;
      Console.WriteLine("\nPartI: The length of the result after {0} ops: {1}", count, GetLength(count, s));
    }

    private static int GetLength(int count, string s)
    {
      for (int i = 0; i < count; i++)
      {
        var sb = new StringBuilder();
        var fragments = Utils.GetFragments(s);

        foreach (var f in fragments)
          sb.Append(Utils.Encode(f));

        s = sb.ToString();
      }

      return s.Length;
    }
  }
}