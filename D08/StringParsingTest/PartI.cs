using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringParsing;

namespace StringParsingTest
{
  [TestClass]
  public class PartI
  {
    [TestMethod]
    public void TC_01()
    {
      string input = "\"jcrkptrsasjp\\\\\\\"cwigzynjgspxxv\\\\vyb\"";
      int expectedCodeChars = 37;
      int expectedInMemoryCharCount = 32;

      var actualCodeChars = Utils.GetCodeCharCount(input);
      var actualInMemoryCharCount = Utils.GetInMemoryCharCount(input);

      Assert.AreEqual(expectedCodeChars, actualCodeChars);
      Assert.AreEqual(expectedInMemoryCharCount, actualInMemoryCharCount);
    }

    [TestMethod]
    public void TC_02()
    {
      string input = "\"rq\\\\\\\"mohnjdf\\\\xv\\\\hrnosdtmvxot\"";
      int expectedCodeChars = 33;
      int expectedInMemoryCharCount = 27;

      var actualCodeChars = Utils.GetCodeCharCount(input);
      var actualInMemoryCharCount = Utils.GetInMemoryCharCount(input);

      Assert.AreEqual(expectedCodeChars, actualCodeChars);
      Assert.AreEqual(expectedInMemoryCharCount, actualInMemoryCharCount);
    }
  }
}
