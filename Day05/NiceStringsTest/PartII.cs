using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiceStrings;

namespace NiceStringsTest
{
  [TestClass]
  public class PartII
  {
    [TestMethod]
    public void TC_01()
    {
      var s1 = "xxyxx";
      var s2 = "qjhvhtzxzqqjkmpb";
      var expected = true;
      bool actual;

      actual = Utils.HasTwoNonOverlappingPairs(s1);
      Assert.AreEqual(expected, actual, "OK!");
      actual = Utils.HasTwoNonOverlappingPairs(s2);
      Assert.AreEqual(expected, actual, "OK!");
    }

    [TestMethod]
    public void TC_02()
    {
      var s = "ieodomkazucvgmuy";
      var expected = false;
      bool actual = Utils.HasTwoNonOverlappingPairs(s);

      Assert.AreEqual(expected, actual, "OK!");
    }
       
    [TestMethod]
    public void TC_03()
    {
      var s = "abcdefeghi";
      var expected = true;
      bool actual = Utils.HasSeparatedDouble(s);

      Assert.AreEqual(expected, actual, "OK!");
    }

    [TestMethod]
    public void TC_04()
    {
      var s = "abcdefxqeghi";
      var expected = false;
      bool actual = Utils.HasSeparatedDouble(s);

      Assert.AreEqual(expected, actual, "OK!");
    }
  }
}
