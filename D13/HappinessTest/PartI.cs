using Happiness;
using Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace HappinessTest
{
  [TestClass]
  public class PartI
  {
    [TestMethod]
    public void TC_01()
    {
      var info = new string[] 
      {
       "Alice would gain 54 happiness units by sitting next to Bob.",
       "Alice would lose 79 happiness units by sitting next to Carol.",
       "Alice would lose 2 happiness units by sitting next to David.",
       "Bob would gain 83 happiness units by sitting next to Alice.",
       "Bob would lose 7 happiness units by sitting next to Carol.",
       "Bob would lose 63 happiness units by sitting next to David.",
       "Carol would lose 62 happiness units by sitting next to Alice.",
       "Carol would gain 60 happiness units by sitting next to Bob.",
       "Carol would gain 55 happiness units by sitting next to David.",
       "David would gain 46 happiness units by sitting next to Alice.",
       "David would lose 7 happiness units by sitting next to Bob.",
       "David would gain 41 happiness units by sitting next to Carol."
      };
      var table = new Table(info);
      var numbers = new List<int>();
      var combinations = table.Persons.Permute().ToList();

      foreach (var combination in combinations)
        numbers.Add(table.CalculateTotalChangeInHappiness(combination.ToList()));

      int expected = 330;
      int actual = numbers.Max();

      Assert.AreEqual(expected, actual, "OK!");
    }
  }
}