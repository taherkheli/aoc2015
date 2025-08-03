namespace aoc.D18
{
  public class Grid
  {
    private int[,] _state;
    private readonly int _rows;
    private readonly int _cols;

    public Grid(int[,] state)
    {
      _state = state;
      _rows = state.GetLength(0);
      _cols = state.GetLength(1);
    }

    public int OnLightsCount(int steps, bool isPartII = false)
    {
      for (int i = 0; i < steps; i++)
        Simulate(isPartII);

      if (isPartII)
        HandleStuckCorners(); // after last iteration, HandleStuckCorners must be called one last time to force all corners to still be ON 

      return GetOnLights();
    }

    private void Simulate(bool isPartII = false)
    {
      var nextState = new int[_rows, _cols];
      if (isPartII)
        HandleStuckCorners();    //before computing next state each time, force corners to be ON

      for (int r = 0; r < _rows; r++)
        for (int c = 0; c < _cols; c++)
          nextState[r, c] = Update(r, c);

      UpdateState(nextState);
    }

    private int Update(int r, int c)
    {
      var isOn = _state[r, c] == 0 ? false : true;
      var neighbours = GetNeighbours(r, c);
      int onCount = 0;

      foreach (var neighbor in neighbours)
        if (_state[neighbor.Item1, neighbor.Item2] == 1)
          onCount++;

      if (isOn)
      {
        if (onCount == 2 || onCount == 3)
          return 1;
        else
          return 0;
      }
      else // isOff
      {
        if (onCount == 3)
          return 1;
        else
          return 0;
      }
    }

    private void UpdateState(int[,] nextState)
    {
      for (int r = 0; r < _rows; r++)
        for (int c = 0; c < _cols; c++)
          _state[r, c] = nextState[r, c];
    }

    private int GetOnLights()
    {
      int sum = 0;

      for (int r = 0; r < _rows; r++)
        for (int c = 0; c < _cols; c++)
          sum += _state[r, c];

      return sum;
    }

    private List<(int, int)> GetNeighbours(int r, int c)
    {
      var result = new List<(int, int)>();

      if (IsNotOutOfBounds(r, c - 1))
        result.Add((r, c-1));

      if (IsNotOutOfBounds(r - 1, c - 1))
        result.Add((r - 1, c - 1));

      if (IsNotOutOfBounds(r - 1, c))
        result.Add((r - 1, c));

      if (IsNotOutOfBounds(r - 1, c + 1))
        result.Add((r - 1, c + 1));

      if (IsNotOutOfBounds(r, c + 1))
        result.Add((r, c + 1));

      if (IsNotOutOfBounds(r + 1, c + 1))
        result.Add((r + 1, c + 1));

      if (IsNotOutOfBounds(r + 1, c))
        result.Add((r + 1, c));

      if (IsNotOutOfBounds(r + 1, c - 1))
        result.Add((r + 1, c - 1));

      return result;
    }

    private bool IsNotOutOfBounds(int r, int c)
    {
      if ((r < 0) || (c < 0) || (r > (_rows - 1)) || (c > (_cols - 1)))
        return false;

      return true;
    }

    private void HandleStuckCorners()
    {
      _state[0, 0] = 1;
      _state[0, _cols - 1] = 1;
      _state[_rows - 1, 0] = 1;
      _state[_rows - 1, _cols - 1] = 1;
    }
  }
}
