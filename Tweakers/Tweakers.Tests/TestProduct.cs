using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweakers.Models;

namespace Tweakers.Tests
{
    [TestClass]
    public class TestProduct
    {
        [TestMethod]
        public void TestConstructor()
        {
            // Properties used declared
            Product product;
            int productId;
            string productName;
            string productBrand;
            string productSKU;
            long productEAN;
            double productARS;
            double productPrice;
            ProductType productProductType;
            Category productCategory;
            List<ProductPicture> productPictures;
            List<ProductSpecification> productSpecs;
            List<UserList> productUserLists;
            List<ProductReview> productReviews;
            List<ShopPrice> productShopPrice;

            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    // Arrange
                    Category category = new Category(1, "CPU");
                    List<ProductPicture> testProductPictures = new List<ProductPicture>();
                    List<ProductSpecification> testProductSpecifications = new List<ProductSpecification>();
                    List<UserList> testUserLists = new List<UserList>();
                    List<ProductReview> testProductReviews = new List<ProductReview>();
                    List<ShopPrice> testShopPrices = new List<ShopPrice>();
                    product = new Product(1, "i7-6800K", "Intel", "BX80671I76800K", 5032037087131, 4.5, 450, category,
                        testProductPictures, testProductSpecifications, testUserLists, testProductReviews, testShopPrices);

                    // Act
                    productId = product.ID;
                    productName = product.Name;
                    productBrand = product.Brand;
                    productSKU = product.SKU;
                    productEAN = product.EAN;
                    productARS = product.AverageReviewScore;
                    productPrice = product.Price;
                    productCategory = product.Category;
                    productPictures = product.ProductPictures;
                    productSpecs = product.ProductSpecifications;
                    productUserLists = product.UserLists;
                    productReviews = product.Reviews;
                    productShopPrice = product.ShopPrices;

                    // Assert
                    Assert.AreEqual(1, productId);
                    Assert.AreEqual("i7-6800K", productName);
                    Assert.AreEqual("Intel", productBrand);
                    Assert.AreEqual("BX80671I76800K", productSKU);
                    Assert.AreEqual(5032037087131, productEAN);
                    Assert.AreEqual(4.5, productARS);
                    Assert.AreEqual(450, productPrice);
                    Assert.AreEqual(category, productCategory);
                    Assert.AreEqual(testProductPictures, productPictures);
                    Assert.AreEqual(testProductSpecifications, productSpecs);
                    Assert.AreEqual(testUserLists, productUserLists);
                    Assert.AreEqual(testProductReviews, productReviews);
                    Assert.AreEqual(testShopPrices, productShopPrice);
                }
                if (i == 1)
                {
                    // Arrange
                    Category category = new Category(1, "CPU");
                    ProductType productType = new ProductType(1, "HEDT");
                    List<ProductPicture> testProductPictures = new List<ProductPicture>();
                    List<ProductSpecification> testProductSpecifications = new List<ProductSpecification>();
                    List<UserList> testUserLists = new List<UserList>();
                    List<ProductReview> testProductReviews = new List<ProductReview>();
                    List<ShopPrice> testShopPrices = new List<ShopPrice>();
                    product = new Product(1, "i7-6800K", "Intel", "BX80671I76800K", 5032037087131, 4.5, 450, productType, category,
                        testProductPictures, testProductSpecifications, testUserLists, testProductReviews, testShopPrices);

                    // Act
                    productId = product.ID;
                    productName = product.Name;
                    productBrand = product.Brand;
                    productSKU = product.SKU;
                    productEAN = product.EAN;
                    productARS = product.AverageReviewScore;
                    productPrice = product.Price;
                    productProductType = product.ProductType;
                    productCategory = product.Category;
                    productPictures = product.ProductPictures;
                    productSpecs = product.ProductSpecifications;
                    productUserLists = product.UserLists;
                    productReviews = product.Reviews;
                    productShopPrice = product.ShopPrices;

                    // Assert
                    Assert.AreEqual(1, productId);
                    Assert.AreEqual("i7-6800K", productName);
                    Assert.AreEqual("Intel", productBrand);
                    Assert.AreEqual("BX80671I76800K", productSKU);
                    Assert.AreEqual(5032037087131, productEAN);
                    Assert.AreEqual(4.5, productARS);
                    Assert.AreEqual(450, productPrice);
                    Assert.AreEqual(productType, productProductType);
                    Assert.AreEqual(category, productCategory);
                    Assert.AreEqual(testProductPictures, productPictures);
                    Assert.AreEqual(testProductSpecifications, productSpecs);
                    Assert.AreEqual(testUserLists, productUserLists);
                    Assert.AreEqual(testProductReviews, productReviews);
                    Assert.AreEqual(testShopPrices, productShopPrice);
                }
            }
        }
    }
}
