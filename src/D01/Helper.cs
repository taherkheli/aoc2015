using System;

namespace aoc.D01
{
	public static class Helper
	{
    public static int GetFloor(string input)
    {
      int floor = 0;
      var directions = input.ToCharArray();

      foreach (var dir in directions)
      {
        if ((dir != '(') && (dir != ')'))
          throw new ArgumentException("Bad input. only ( or ) is valid!");

        if (dir == '(')
          floor += 1;
        else
          floor -= 1;
      }

      return floor;
    }

    public static int IndexAtEnteringBasement(string input)
    {
      int result = 0;
      int floor = 0;

      for (int i = 0; i < input.Length; i++)
      {
        if ((input[i] != '(') && (input[i] != ')'))
          throw new ArgumentException("Bad input. only ( or ) is valid!");

        if (input[i] == '(')
          floor += 1;
        else
        {
          floor -= 1;

          if (floor < 0)
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
