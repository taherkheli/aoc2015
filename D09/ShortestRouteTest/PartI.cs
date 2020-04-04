using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortestRoute;
using System.Collections.Generic;

namespace ShortestRouteTest
{
  [TestClass]
  public class PartI
  {
    [TestMethod]
    public void TC_01()
    {

      var lines = new string[] 
      {
        "London to Dublin = 464",
        "London to Belfast = 518",
        "Dublin to Belfast = 141"
      };
      
      var world = new World(lines);
      
      int expLondon = 605;
      int expDublin = 659;
      int expBelfast = 605;

      int actLondon = world.Cities[0].ShortestAndLongestRouteDistance(world).Item1;
      int actDublin = world.Cities[1].ShortestAndLongestRouteDistance(world).Item1; 
      int actBelfast = world.Cities[2].ShortestAndLongestRouteDistance(world).Item1; ;

      Assert.AreEqual(expLondon, actLondon, "OK!");
      Assert.AreEqual(expDublin, actDublin, "OK!");
      Assert.AreEqual(expBelfast, actBelfast, "OK!");
    }
  }
}
