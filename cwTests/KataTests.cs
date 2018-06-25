using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cw.Tests
{
    [TestClass()]
    public class KataTests
    {
        [TestMethod()]
        public void AdditionTest()
        {
            Assert.AreNotEqual(Kata.Addition(2, 2), 5);
            Assert.AreEqual(Kata.Addition(2, 2), 4);
        }

    }
}
