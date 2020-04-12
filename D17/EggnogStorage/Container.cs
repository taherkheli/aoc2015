namespace EggnogStorage
{
  public class Container
  {
    private readonly int _id;

    private readonly int _capacity;

    public Container(int id, int capacity)
    {
      _id = id;
      _capacity = capacity;
    }

    public int Id => _id;

    public int Capacity => _capacity;
  }
}
