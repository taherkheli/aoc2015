namespace BitwiseLogic
{
  class Program
  {
    static void Main()
    {
      string path = "input.txt";
      var instructions = Utils.Parse(path);
      
      var sorter = new Sorter();
      instructions = sorter.SortTopographically(instructions);

      foreach (var inst in instructions)
      {
        //inst.Execute();
      }
      
    }

  }
}
