using Microsoft.VisualStudio.TestTools.UnitTesting;
using WrappingPaper;

namespace WrappingPaperTest
{
  [TestClass]
  public class BoxTest
  {
    [TestMethod]
    public void TC_01()
    {
      var box = new Box(2, 3, 4);
      int expected = 58;
      int actual = box.GetWrapperPaperNeeded();

      Assert.AreEqual(expected, actual, "OK!");
    }

    [TestMethod]
    public void TC_02()
    {
      var box = new Box(1, 1, 10);
      int expected = 43;
      int actual = box.GetWrapperPaperNeeded();

      Assert.AreEqual(expected, actual, "OK!");
    }

    [TestMethod]
    public void TC_03()
    {
      var box = new Box(2, 3, 4);
      int expected = 34;
      int actual = box.GetRibbonNeeded();

      Assert.AreEqual(expected, actual, "OK!");
    }

    [TestMethod]
    public void TC_04()
    {
      var box = new Box(1, 1, 10);
      int expected = 14;
      int actual = box.GetRibbonNeeded();

      Assert.AreEqual(expected, actual, "OK!");
    }
  }
}
