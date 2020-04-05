namespace PasswordPolicy
{
  public static class Password
  {
    public static string GetNextValidPassword(string s)
    {
      var result = string.Empty;
      var temp = s;

      while (true)
      {
        temp = Utils.Increment(temp);

        if (Utils.HasForbiddenChars(temp))
          continue;
        else
        {
          if (Utils.HasIncreasingStraight(temp))
          {
            if (Utils.HasTwoDoubles(temp))
            {
              result = temp;
              break;
            }
            else
              continue;
          }
          else
          {
            continue;
          }
        }
      }

      return result;
    }
  }
}
