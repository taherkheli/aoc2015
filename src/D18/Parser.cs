namespace aoc.D18
{
  public static class Parser
  {
    public static int[,] Parse(string path)
    {
      var lines = File.ReadAllLines(path);
      int rows = lines.Length;
      int cols = lines[0].Length;
      var state = new int[rows, cols];

      for (int r = 0; r < rows; r++)
        for (int c = 0; c < cols; c++)
          state[r, c] = lines[r][c] == '#' ? 1 : 0;

      return state;
    }

    public static void Print(int[,] state)
    {
      int rows = state.GetLength(0);
      int cols = state.GetLength(1);

      using StreamWriter writer = new("output.txt");
      for (int r = 0; r < rows; r++)
      {
        for (int c = 0; c < cols; c++)
        {
          writer.Write(state[r, c] == 1 ? '#' : '.');
        }

        writer.WriteLine();
      }
    }
  }
}
