using Lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Happiness
{
  class Program
  {
    static void Main()
    {
      var path = "input.txt";
      var info = Utils.Parse(path);
      var table = new Table(info);
      
      var numbers = new List<int>();
      var combinations = table.Persons.Permute().ToList();

      foreach (var combination in combinations)
        numbers.Add(table.CalculateTotalChangeInHappiness(combination.ToList()));
      
      Console.WriteLine("\nPartI Maximum possible change in happiness is : {0}", numbers.Max());

      numbers = new List<int>();
      table.AddPerson(new Person("Bilal"));
      combinations = table.Persons.Permute().ToList();

      foreach (var combination in combinations)
        numbers.Add(table.CalculateTotalChangeInHappiness(combination.ToList()));

      Console.WriteLine("\nPartII Maximum possible change in happiness after seating myself is : {0}", numbers.Max());
    }
  }
}
