using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweakers.Models;

namespace Tweakers.Tests
{
    [TestClass]
    public class TestProductPicture
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Arrange
            ProductPicture productPicture = new ProductPicture(1, "https://ic.tweakimg.net/ext/i/2001104165.jpeg");

            // Act
            int productPictureId = productPicture.ID;
            string productPictureLink = productPicture.PictureURL;

            // Assert
            Assert.AreEqual(1, productPictureId);
            Assert.AreEqual("https://ic.tweakimg.net/ext/i/2001104165.jpeg", productPictureLink);
        }
    }
}
