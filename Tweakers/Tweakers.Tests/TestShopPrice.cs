using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweakers.Models;

namespace Tweakers.Tests
{
    [TestClass]
    public class TestShopPrice
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Arrange
            Shop shop = new Shop(1, "4Launch");
            ShopPrice shopPrice = new ShopPrice(shop, 400,
                "https://www.4launch.nl/product/390646/Intel-Broadwell-E-i7-6800K-3-40GHz-15MB-Box/tweakers");

            // Act
            Shop shopPriceShop = shopPrice.Shop;
            double shopPricePrice = shopPrice.Price;
            string shopPriceProductURL = shopPrice.ProductURL;

            // Assert
            Assert.AreEqual(shop, shopPriceShop);
            Assert.AreEqual(400, shopPricePrice);
            Assert.AreEqual(
                "https://www.4launch.nl/product/390646/Intel-Broadwell-E-i7-6800K-3-40GHz-15MB-Box/tweakers",
                shopPriceProductURL);
        }
    }
}
