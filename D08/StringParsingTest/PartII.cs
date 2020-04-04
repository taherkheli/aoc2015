using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringParsing;

namespace StringParsingTest
{
  [TestClass]
  public class PartII
  {
    [TestMethod]
    public void TC_01()
    {
      string[] lines = new string[]
      {
        "\"\"",
        "\"abc\"",
        "\"aaa\\\"aaa\"",
        "\"\\x27\""
      };      
      int sumA = 0;
      int sumB = 0;
      int expected = 19;

      foreach (var s in lines)
      {
        int x = Utils.GetCodeCharCount(s);
        sumA += x;
        var encodedString = Utils.Encode(s);
        int z = Utils.GetCodeCharCount(encodedString);
        sumB += z;
      }

      int actual = sumB - sumA;

      Assert.AreEqual(expected, actual, "OK!");
    }
  }
}
