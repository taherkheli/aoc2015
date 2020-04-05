using System;

namespace PasswordPolicy
{
  class Program
  {
    static void Main()
    {
      var input = "cqjxjnds";
      var partI = Password.GetNextValidPassword(input);      
      Console.WriteLine("\nPartI:  The next valid password is: {0}", partI);

      input = partI;
      var partII = Password.GetNextValidPassword(input);
      Console.WriteLine("\nPartII: The next valid password is: {0}", partII);
    }
  }
}
