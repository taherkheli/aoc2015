namespace aoc.D15
{
  public class CookieMaker(Ingredient[] ingredients)
  {
    private readonly Ingredient[] _ingredients = ingredients;
    private const int total = 100;

    public int GetHighestScoringCookie(bool isPartII = false)
    {
      var cookie = new Cookie(_ingredients);
      var maxScore = int.MinValue;

      for (int a = 0; a < total; a++)
      {
        for (int b = 0; b < total - a; b++)
        {
          for (int c = 0; c < total - a - b; c++)
          {
            var d = total - a - b - c;
            cookie.Cfg = [a, b, c, d];
            var score = cookie.Calculate().Item1;
            var sellable = cookie.Calculate().Item2;
            if (isPartII)
            {
              if (sellable && (score > maxScore))
                maxScore = score;
            }
            else 
            {
              if (score > maxScore)
                maxScore = score;
            }
          }
        }
      }

      return maxScore;
    }
  }
}

