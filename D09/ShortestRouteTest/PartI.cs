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
      var distances = new List<int>();
      
      int expLondon = 605;
      int expDublin = 659;
      int expBelfast = 605;

      int actLondon = world.Cities[0].ShortestRouteDistance(world);
      int actDublin = world.Cities[1].ShortestRouteDistance(world); 
      int actBelfast = world.Cities[2].ShortestRouteDistance(world); ;

      Assert.AreEqual(expLondon, actLondon, "OK!");
      Assert.AreEqual(expDublin, actDublin, "OK!");
      Assert.AreEqual(expBelfast, actBelfast, "OK!");
    }
  }
}
