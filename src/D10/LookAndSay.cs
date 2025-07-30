using System.Text;

namespace aoc.D10
{
  public static class LookAndSay 
  {

    public static int Solve(string s, int loopCount)
    {
      string result = s;
      
      for (int i =0; i < loopCount; i++) 
      {
        int j = 0;
        var sb = new StringBuilder();

        while(j < result.Length)
        {
          var occurences = CountSuccessiveOccurences(result, j);
          sb.Append(occurences);
          sb.Append(result[j]);
          j += occurences;
        }

        result = sb.ToString();
      }

      return result.Length; 
    }

    // count successive occurences of the charcater located at index
    private static int CountSuccessiveOccurences(string s, int index)
    {
      var character = s[index];
      int count = 1;

      for (int i = index + 1; i < s.Length; i++)
      {
        if (character == s[i])
          count++;
        else
          break;
      }

      return count;
    }
  }
}