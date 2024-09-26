using HealthApp.Server.Services;

namespace ServerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual((decimal)1.2, ActivityLevelMethods.GetActivityValue("sedentary"),"GetActiveValue for sedentary did not match expected value");
            Assert.AreNotEqual((decimal)1.3, ActivityLevelMethods.GetActivityValue("active"), "GetActicityValue for sedentary matched the wrong value");
        }
    }
}