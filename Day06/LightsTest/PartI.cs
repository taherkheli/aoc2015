using Lights;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightsTest
{
  [TestClass]
  public class PartI
  {
    [TestMethod]
    public void TC_01()
    {
      int size = 1000; 
      
      var lines = new string[] 
      {
        "turn on 0,0 through 999,999",
        "toggle 0,0 through 999,0",
        "turn off 499,499 through 500,500"
      };

      int expected = 998996;      

      var cmds = Utils.Parse(lines);
      var grid = new Grid(size, size);

      foreach (var cmd in cmds)
        grid.Execute(cmd);

      int actual = grid.LitCount;
      Assert.AreEqual(expected, actual, "OK!");
    }
  }
}
