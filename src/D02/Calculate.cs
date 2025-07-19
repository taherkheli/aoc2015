namespace aoc.D02
{
  public static class Calculate
  {
    public static int WrappingPaper(Box[] boxes)
    {
      int sum = 0;

      foreach (var box in boxes)
        sum += box.GetWrapperPaperNeeded();

      return sum;
    }

    public static int Ribbon(Box[] boxes)
    {
      int sum = 0;

      foreach (var box in boxes)
        sum += box.GetRibbonNeeded();

      return sum;
    }
  }
}
