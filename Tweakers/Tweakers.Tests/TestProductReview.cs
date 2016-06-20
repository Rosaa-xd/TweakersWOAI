using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweakers.Models;

namespace Tweakers.Tests
{
    [TestClass]
    public class TestProductReview
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Properties used delcared
            ProductReview productReview;
            int productReviewId;
            User productReviewUser;
            Product productReviewProduct;
            DateTime productReviewDateTime;
            int productReviewScore;
            string productReviewExplanation;
            List<Asset> productReviewAssets;

            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    // Arrange
                    User user = new User(1, "test", "test");
                    DateTime time = DateTime.Now;
                    productReview = new ProductReview(1, user, time, 4, "test");

                    // Act
                    productReviewId = productReview.ID;
                    productReviewUser = productReview.User;
                    productReviewDateTime = productReview.Date;
                    productReviewScore = productReview.Score;
                    productReviewExplanation = productReview.Explanation;

                    // Assert
                    Assert.AreEqual(1, productReviewId);
                    Assert.AreEqual(user, productReviewUser);
                    Assert.AreEqual(time, productReviewDateTime);
                    Assert.AreEqual(4, productReviewScore);
                    Assert.AreEqual("test", productReviewExplanation);
                }
                if (i == 1)
                {
                    // Arrange
                    User user = new User(1, "test", "test");
                    DateTime time = DateTime.Now;
                    List<Asset> assets = new List<Asset>();
                    productReview = new ProductReview(1, user, time, 4, "test", assets);

                    // Act
                    productReviewId = productReview.ID;
                    productReviewUser = productReview.User;
                    productReviewDateTime = productReview.Date;
                    productReviewScore = productReview.Score;
                    productReviewExplanation = productReview.Explanation;
                    productReviewAssets = productReview.Assets;

                    // Assert
                    Assert.AreEqual(1, productReviewId);
                    Assert.AreEqual(user, productReviewUser);
                    Assert.AreEqual(time, productReviewDateTime);
                    Assert.AreEqual(4, productReviewScore);
                    Assert.AreEqual("test", productReviewExplanation);
                    Assert.AreEqual(assets, productReviewAssets);
                }
                if (i == 2)
                {
                    // Arrange
                    User user = new User(1, "test", "test");
                    Product product = new Product(1, "test", "test", "test", 123, 4, 4,
                        null, null, null, null, null, null);
                    DateTime time = DateTime.Now;
                    productReview = new ProductReview(user, product, time, 4, "test");

                    // Act
                    productReviewUser = productReview.User;
                    productReviewProduct = productReview.Product;
                    productReviewDateTime = productReview.Date;
                    productReviewScore = productReview.Score;
                    productReviewExplanation = productReview.Explanation;

                    // Assert
                    Assert.AreEqual(user, productReviewUser);
                    Assert.AreEqual(product, productReviewProduct);
                    Assert.AreEqual(time, productReviewDateTime);
                    Assert.AreEqual(4, productReviewScore);
                    Assert.AreEqual("test", productReviewExplanation);
                }
                if (i == 3)
                {
                    // Arrange
                    User user = new User(1, "test", "test");
                    Product product = new Product(1, "test", "test", "test", 123, 4, 4,
                        null, null, null, null, null, null);
                    DateTime time = DateTime.Now;
                    List<Asset> assets = new List<Asset>();
                    productReview = new ProductReview(user, product, time, 4, "test", assets);

                    // Act
                    productReviewUser = productReview.User;
                    productReviewProduct = productReview.Product;
                    productReviewDateTime = productReview.Date;
                    productReviewScore = productReview.Score;
                    productReviewExplanation = productReview.Explanation;
                    productReviewAssets = productReview.Assets;

                    // Assert
                    Assert.AreEqual(user, productReviewUser);
                    Assert.AreEqual(product, productReviewProduct);
                    Assert.AreEqual(time, productReviewDateTime);
                    Assert.AreEqual(4, productReviewScore);
                    Assert.AreEqual("test", productReviewExplanation);
                    Assert.AreEqual(assets, productReviewAssets);
                }
            }
        }
    }
}
