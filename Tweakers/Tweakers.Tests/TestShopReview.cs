using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweakers.Models;

namespace Tweakers.Tests
{
    [TestClass]
    public class TestShopReview
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Properties used delcared
            ShopReview shopReview;
            int shopReviewId;
            User shopReviewUser;
            Shop shopReviewShop;
            DateTime shopReviewDateTime;
            int shopReviewSGeneral;
            string shopReviewEGeneral;
            int shopReviewSDelivery;
            string shopReviewEDelivery;
            int shopReviewSCustomerService;
            string shopReviewECustomerService;

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    // Arrange
                    User user = new User(1, "test", "test");
                    Shop shop = new Shop(1, "4Launch");
                    DateTime time = DateTime.Now;
                    shopReview = new ShopReview(1, user, shop, time, 3, "test", 3, "test", 3, "test");

                    // Act
                    shopReviewId = shopReview.ID;
                    shopReviewUser = shopReview.User;
                    shopReviewShop = shopReview.Shop;
                    shopReviewDateTime = shopReview.Date;
                    shopReviewSGeneral = shopReview.SGeneral;
                    shopReviewEGeneral = shopReview.EGeneral;
                    shopReviewSDelivery = shopReview.SDelivery;
                    shopReviewEDelivery = shopReview.EDelivery;
                    shopReviewSCustomerService = shopReview.SCustomerService;
                    shopReviewECustomerService = shopReview.ECustomerService;

                    // Assert
                    Assert.AreEqual(1, shopReviewId);
                    Assert.AreEqual(user, shopReviewUser);
                    Assert.AreEqual(shop, shopReviewShop);
                    Assert.AreEqual(time, shopReviewDateTime);
                    Assert.AreEqual(3, shopReviewSGeneral);
                    Assert.AreEqual("test", shopReviewEGeneral);
                    Assert.AreEqual(3, shopReviewSDelivery);
                    Assert.AreEqual("test", shopReviewEDelivery);
                    Assert.AreEqual(3, shopReviewSCustomerService);
                    Assert.AreEqual("test", shopReviewECustomerService);
                }
                if (i == 1)
                {
                    // Arrange
                    User user = new User(1, "test", "test");
                    Shop shop = new Shop(1, "4Launch");
                    DateTime time = DateTime.Now;
                    shopReview = new ShopReview(user, shop, time, 3, "test", 3, "test", 3, "test");

                    // Act
                    shopReviewUser = shopReview.User;
                    shopReviewShop = shopReview.Shop;
                    shopReviewDateTime = shopReview.Date;
                    shopReviewSGeneral = shopReview.SGeneral;
                    shopReviewEGeneral = shopReview.EGeneral;
                    shopReviewSDelivery = shopReview.SDelivery;
                    shopReviewEDelivery = shopReview.EDelivery;
                    shopReviewSCustomerService = shopReview.SCustomerService;
                    shopReviewECustomerService = shopReview.ECustomerService;

                    // Assert
                    Assert.AreEqual(user, shopReviewUser);
                    Assert.AreEqual(shop, shopReviewShop);
                    Assert.AreEqual(time, shopReviewDateTime);
                    Assert.AreEqual(3, shopReviewSGeneral);
                    Assert.AreEqual("test", shopReviewEGeneral);
                    Assert.AreEqual(3, shopReviewSDelivery);
                    Assert.AreEqual("test", shopReviewEDelivery);
                    Assert.AreEqual(3, shopReviewSCustomerService);
                    Assert.AreEqual("test", shopReviewECustomerService);
                }
            }
        }
    }
}
