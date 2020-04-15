using System;

namespace CookieMaking
{
  class Program
  {
    static void Main()
    {
      const int total = 100;
      var path = "input.txt";
      var ingredients = Utils.Parse(path);
      var cookie = new Cookie(ingredients);

      var maxScore = int.MinValue;
      var maxScore500 = int.MinValue;


      for (int a = 0; a < total; a++)
      {
        for (int b = 0; b < total - a; b++)
        {
          for (int c = 0; c < total - a - b; c++)
          {
            var d = total - a - b - c;
            //Console.WriteLine("a:[{0}]   b:[{1}]   c:[{2}]   d:[{3}]", a, b, c, d);
            var cfg = new int[4] { a, b, c, d };
            cookie.Cfg = cfg;
            var score = cookie.Calculate().Item1;
            var sellable = cookie.Calculate().Item2;

            if (score > maxScore)
              maxScore = score;

            if (sellable && (score > maxScore500))
              maxScore500 = score;
          }
        }
      }

      Console.WriteLine("\nPartI: The total score of the highest-scoring cookie: {0}", maxScore);
      Console.WriteLine("\nPartII: The total score of the highest-scoring 500 cal cookie: {0}", maxScore500);
    }
  }
}
