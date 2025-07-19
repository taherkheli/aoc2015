namespace aoc.D01
{
  public static class Parser
  {
    public static string Parse(string path) 
    {
      return new StreamReader(path).ReadToEnd();
    }
  }
}
