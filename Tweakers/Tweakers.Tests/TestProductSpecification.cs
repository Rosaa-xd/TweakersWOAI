using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweakers.Models;

namespace Tweakers.Tests
{
    [TestClass]
    public class TestProductSpecification
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Arrange
            ProductSpecification productSpecification = new ProductSpecification("Kloksnelheid", "3,4 GHz");

            // Act
            string productSpecName = productSpecification.Name;
            string productSpecValue = productSpecification.Value;

            // Assert
            Assert.AreEqual("Kloksnelheid", productSpecName);
            Assert.AreEqual("3,4 GHz", productSpecValue);
        }
    }
}
