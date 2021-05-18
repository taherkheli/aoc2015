using System.Security.Cryptography;
using System.Text;

namespace aoc.D04
{
  public class MD5Hash
  {
    private string _input;
    private int _number;

    public MD5Hash(string input)
    {
      _input = input;
      _number = 0;
    }

    public int PartI()
    {
      _number = 0;

      while (true)
      {
        var temp = _input + _number.ToString();
        temp = Calculate(temp);

        if (ConditionMet(temp))
          break;
        else
          _number++;
      }

      return _number;
    }

    public int PartII()
    {
      _number = 0;

      while (true)
      {
        var temp = _input + _number.ToString();
        temp = Calculate(temp);

        if (ConditionMetPartII(temp))
          break;
        else
          _number++;
      }

      return _number;
    }

    private string Calculate(string input)
    {
      // step 1, calculate MD5 hash from input
      MD5 md5 = MD5.Create();
      byte[] inputBytes = Encoding.ASCII.GetBytes(input);
      byte[] hash = md5.ComputeHash(inputBytes);

      // step 2, convert byte array to hex string
      StringBuilder sb = new StringBuilder();
      for (int i = 0; i < hash.Length; i++)
        sb.Append(hash[i].ToString("X2"));

      return sb.ToString();
    }

    private bool ConditionMet(string s)
    {
      if ((s[0] == '0') && (s[1] == '0') && (s[2] == '0') && (s[3] == '0') && (s[4] == '0'))
        return true;
      else
        return false;
    }

    private bool ConditionMetPartII(string s)
    {
      if ((s[0] == '0') && (s[1] == '0') && (s[2] == '0') && (s[3] == '0') && (s[4] == '0') && (s[5] == '0'))
        return true;
      else
        return false;
    }
  }
}
