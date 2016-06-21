using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweakers.Models;

namespace Tweakers.Tests
{
    [TestClass]
    public class TestShop
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Arrange
            Shop shop = new Shop(1, "4Launch");

            // Act
            int shopId = shop.ID;
            string shopName = shop.Name;

            // Assert
            Assert.AreEqual(1, shopId);
            Assert.AreEqual("4Launch", shopName);
        }
    }
}
