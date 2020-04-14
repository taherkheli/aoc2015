namespace FirstComputer
{
  class Program
  {
    static void Main()
    {
      var path = "input.txt";
      var program = Utils.Parse(path);
      var computer = new Computer(program);
      computer.Execute();
      System.Console.WriteLine("\nPartI: after execution register B has vale: {0}", computer.B);
      
      computer = new Computer(program, true);
      computer.Execute();
      System.Console.WriteLine("\nPartII: after execution register B has vale: {0}", computer.B);
    }
  }
}
