namespace aoc.D01
{
	public static class Building
	{

    public static int Solve(string input, bool isPartII = false)
    {
      int result = 0;

      for (int i = 0; i < input.Length; i++) 
      {
        if (input[i] == '(')
          result++;
        else if (input[i] == ')')
          result--;

        if (isPartII)
        {
          if (result < 0)
          {
            result = i + 1;
            break;
          }
        }
      }

      return result;
    }
  }
}
