namespace aoc.Common
{
  public static class Parser
  {
    public static string Parse(string path) 
    {
      return new StreamReader(path).ReadToEnd();
    }
  }
}
