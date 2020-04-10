namespace Happiness
{
  public class Person
  {
    private readonly string _name;

    public Person(string name)
    {
      _name = name;
    }

    public string Name => _name;
  }
}