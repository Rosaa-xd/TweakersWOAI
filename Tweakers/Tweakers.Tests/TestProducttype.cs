using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweakers.Models;

namespace Tweakers.Tests
{
    [TestClass]
    public class TestProducttype
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Arrange
            ProductType productType = new ProductType(1, "HEDT");

            // Act
            int productTypeId = productType.ID;
            string productTypeName = productType.Name;

            // Assert
            Assert.AreEqual(1, productTypeId);
            Assert.AreEqual("HEDT", productTypeName);
        }
    }
}
