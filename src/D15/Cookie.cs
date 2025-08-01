namespace aoc.D15
{
  public class Cookie
  {
    private readonly Ingredient[] _ingredients;
    private int[] _cfg;

    public Cookie(Ingredient[] ingredients)
    {
      _ingredients = ingredients;
      _cfg = new int[4];

      for (int i = 0; i < _cfg.Length; i++)
        _cfg[i] = 0;
    }

    public int[] Cfg { get => _cfg; set => _cfg = value; }

    public (int, bool) Calculate()
    {
      var sellable = false;

      int calorieCount = _cfg[0] * _ingredients[0].Calories + _cfg[1] * _ingredients[1].Calories + _cfg[2] * _ingredients[2].Calories + _cfg[3] * _ingredients[3].Calories;
      if (calorieCount == 500)
        sellable = true; ;

      int capacity = _cfg[0] * _ingredients[0].Capacity + _cfg[1] * _ingredients[1].Capacity + _cfg[2] * _ingredients[2].Capacity + _cfg[3] * _ingredients[3].Capacity;
      if (capacity < 0)
        capacity = 0;

      int durability = _cfg[0] * _ingredients[0].Durability + _cfg[1] * _ingredients[1].Durability + _cfg[2] * _ingredients[2].Durability + _cfg[3] * _ingredients[3].Durability;
      if (durability < 0)
        durability = 0;

      int flavor = _cfg[0] * _ingredients[0].Flavor + _cfg[1] * _ingredients[1].Flavor + _cfg[2] * _ingredients[2].Flavor + _cfg[3] * _ingredients[3].Flavor;
      if (flavor < 0)
        flavor = 0;

      int texture = _cfg[0] * _ingredients[0].Texture + _cfg[1] * _ingredients[1].Texture + _cfg[2] * _ingredients[2].Texture + _cfg[3] * _ingredients[3].Texture;
      if (texture < 0)
        texture = 0;

      return (capacity * durability * flavor * texture, sellable);
    }
  }
}
