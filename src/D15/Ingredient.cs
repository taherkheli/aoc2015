namespace aoc.D15
{
  public class Ingredient
  {
    private int _capacity;
    private int _durability;
    private int _flavor;
    private int _texture;
    private int _calories;

    public Ingredient()
    {
      _capacity = 0;
      _durability = 0;
      _flavor = 0;
      _texture = 0;
      _calories = 0;
    }

    public Ingredient(int capacity,
                      int durability,
                      int flavor,
                      int texture,
                      int calories)
    {
      _capacity = capacity;
      _durability = durability;
      _flavor = flavor;
      _texture = texture;
      _calories = calories;
    }

    public int Capacity { get => _capacity; set => _capacity = value; }
    public int Durability { get => _durability; set => _durability = value; }
    public int Flavor { get => _flavor; set => _flavor = value; }
    public int Texture { get => _texture; set => _texture = value; }
    public int Calories { get => _calories; set => _calories = value; }
  }
}
