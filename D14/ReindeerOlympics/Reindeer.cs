namespace ReindeerOlympics
{
  public class Reindeer
  {
    private readonly string _name;
    private readonly int _speed;
    private readonly int _flightDuration;
    private readonly int _restDuration;

    public Reindeer()
    {
    }

    public Reindeer(string name, int speed, int flightDuration, int restDuration)
    {
      _name = name;
      _speed = speed;
      _flightDuration = flightDuration;
      _restDuration = restDuration;
    }

    public int DistanceTravelled(int t)
    {
      int cycles = t / (_flightDuration + _restDuration);
      int fragment = t % (_flightDuration + _restDuration);

      if (fragment > _flightDuration)
        fragment = _flightDuration;

      int speed = (cycles * _flightDuration * _speed) + (fragment * _speed);  

      return speed;
    }

  }
}
