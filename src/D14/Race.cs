using aoc.Helpers;

namespace aoc.D14
{
  public class Race(Reindeer[] reindeers)
  {
    private Reindeer[] _reindeers = reindeers;

    public int GetDistanceTravelledByWinner(int duration)
    {
      var distances = new int[_reindeers.Length];

      for (int i = 0; i < _reindeers.Length; i++)
        distances[i] = _reindeers[i].DistanceTravelled(duration);

      return Utils.GetLargest(distances);
    }

    public int GetPointsAccumulatedByWinner(int duration)
    {
      foreach (var r in _reindeers)
        r.Reset();

      for (int i = 0; i < duration; i++)
      {
        foreach (var r in _reindeers)
          r.Increment();

        EvaluateAndScore();
      }

      return _reindeers.OrderByDescending(o => o.Points).ToList().First().Points;
    }

    public void EvaluateAndScore()
    {
      var list = _reindeers.OrderByDescending(r => r.CurrentDistance).ToList();
      var distance = list[0].CurrentDistance;
      var winners = list.FindAll(r => r.CurrentDistance == distance);

      foreach (var r in winners)
        r.Points++;
    }
  }
}
