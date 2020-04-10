using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordPolicy;

namespace PasswordPolicyTest
{
  [TestClass]
  public class PartI
  {
    [TestMethod]
    public void TC_01_Increment()
    {
      var s = "aaaaaaaa";
      var expected = "aaaaaelk";

      for (int i = 0; i < 3000; i++)
        s = Utils.Increment(s);

      var actual = s;

      Assert.AreEqual(expected, actual, "OK!");
    }

    [TestMethod]
    public void TC_02_HasIncreasingStraight()
    {
      var s1 = "hijklmmn";
      var s2 = "abbceffg";
      var s3 = "atgyzars";   //xya is not a valid straight

      var expected1 = true;
      var expected2 = false;
      var expected3 = false;

      var actual1 = Utils.HasIncreasingStraight(s1);
      var actual2 = Utils.HasIncreasingStraight(s2);
      var actual3 = Utils.HasIncreasingStraight(s3);

      Assert.AreEqual(expected1, actual1, "OK!");
      Assert.AreEqual(expected2, actual2, "OK!");
      Assert.AreEqual(expected3, actual3, "OK!");
    }

    [TestMethod]
    public void TC_03_HasTwoDoubles()
    {
      var s1 = "abbceffg";
      var s2 = "abbcebbg";
      var s3 = "abbbbbbce";
      var s4 = "abbbbbbceggg";
      var s5 = "abbbbbbcxdbbleggg";

      var expected1 = true;
      var expected2 = false;
      var expected3 = false;
      var expected4 = true;
      var expected5 = true;

      var actual1 = Utils.HasTwoDoubles(s1); 
      var actual2 = Utils.HasTwoDoubles(s2); 
      var actual3 = Utils.HasTwoDoubles(s3); 
      var actual4 = Utils.HasTwoDoubles(s4);
      var actual5 = Utils.HasTwoDoubles(s5);

      Assert.AreEqual(expected1, actual1, "OK!");
      Assert.AreEqual(expected2, actual2, "OK!");
      Assert.AreEqual(expected3, actual3, "OK!");
      Assert.AreEqual(expected4, actual4, "OK!");
      Assert.AreEqual(expected5, actual5, "OK!");
    }
  }
}
