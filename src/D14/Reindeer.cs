namespace aoc.D14
{
  public class Reindeer
  {
    private readonly string _name;
    private readonly int _speed;
    private readonly int _flightDuration;
    private readonly int _restDuration;
    private int _currentDistance;
    private int _currentTime;
    private int _points;

    public Reindeer(string name, int speed, int flightDuration, int restDuration)
    {
      _name = name;
      _speed = speed;
      _flightDuration = flightDuration;
      _restDuration = restDuration;
      _currentDistance = 0;
      _currentTime = 0;
      _points = 0;
    }

    public int CurrentDistance { get => _currentDistance; }
    public int Points { get => _points; set => _points = value; }

    public void Reset()
    {
      _currentDistance = 0;
      _currentTime = 0;
      _points = 0;
    }

    public void Increment()
    {
      _currentDistance = DistanceTravelled(++_currentTime);
    }

    public int DistanceTravelled(int t)
    {
      int cycles = t / (_flightDuration + _restDuration);
      int fragment = t % (_flightDuration + _restDuration);

      if (fragment > _flightDuration)
        fragment = _flightDuration;

      int distance = (cycles * _flightDuration * _speed) + (fragment * _speed);

      return distance;
    }
  }
}
