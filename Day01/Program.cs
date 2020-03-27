using System;
using System.IO;

namespace Day01
{
  class Program
  {
    static void Main()
    {
      string path = "input.txt";
      Console.WriteLine("\nPart I:  Instructions took Santa to floor: {0}", GetFloor(LoadInput(path)));

      Console.WriteLine("\nPart II:  Position of the chracter that made Santa enter the floor: {0}", IndexAtEnteringBasement(LoadInput(path)));
    }

    private static int GetFloor(string input)    
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

    private static int IndexAtEnteringBasement(string input)
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

    private static string LoadInput(string path)
    {
      return new StreamReader(path).ReadToEnd();
    }
  }
}
