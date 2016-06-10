using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    public class Product : DbContext
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string SKU { get; set; }
        public long EAN { get; set; }
        public double AverageReviewScore { get; set; }
        public double Price { get; set; }
        public ProductType ProductType { get; set; }
        public Category Category { get; set; }
        public List<ProductPicture> ProductPictures;
        public List<ProductSpecification> ProductSpecifications;
        public List<UserList> UserLists;
        public List<ProductReview> Reviews;
        public List<ShopPrice> ShopPrices;

        #region Constructors

        public Product(int id, string name, string brand, string sku, long ean, ProductType productType, Category category)
        {
            ID = id;
            Name = name;
            Brand = brand;
            SKU = sku;
            EAN = ean;
            ProductType = productType;
            Category = category;
        }
        
        public Product(int id, string name, string brand, string sku, long ean, double averageReviewScore, double price,
            ProductType productType, Category category)
        {
            ID = id;
            Name = name;
            Brand = brand;
            SKU = sku;
            EAN = ean;
            AverageReviewScore = averageReviewScore;
            Price = price;
            ProductType = productType;
            Category = category;
        }

        public Product(int id, string name, string brand, string sku, long ean, double averageReviewScore, double price,
            Category category)
        {
            ID = id;
            Name = name;
            Brand = brand;
            SKU = sku;
            EAN = ean;
            AverageReviewScore = averageReviewScore;
            Price = price;
            Category = category;
        }

        public Product(string name, string brand, string sku, long ean, ProductType productType, Category category,
            List<ProductPicture> productPictures, List<ProductSpecification> productSpecifications,
            List<UserList> userLists, List<ProductReview> reviews, List<ShopPrice> shopPrices)
        {
            Name = name;
            Brand = brand;
            SKU = sku;
            EAN = ean;
            ProductType = productType;
            Category = category;
            ProductPictures = productPictures;
            ProductSpecifications = productSpecifications;
            UserLists = userLists;
            Reviews = reviews;
            ShopPrices = shopPrices;
        }

        public Product(string name, string brand, string sku, long ean, Category category,
            List<ProductPicture> productPictures, List<ProductSpecification> productSpecifications,
            List<UserList> userLists, List<ProductReview> reviews, List<ShopPrice> shopPrices)
        {
            Name = name;
            Brand = brand;
            SKU = sku;
            EAN = ean;
            Category = category;
            ProductPictures = productPictures;
            ProductSpecifications = productSpecifications;
            UserLists = userLists;
            Reviews = reviews;
            ShopPrices = shopPrices;
        }

        public Product(int id, string name, string brand, string sku, long ean, double averageReviewScore, double price, Category category,
            List<ProductPicture> productPictures, List<ProductSpecification> productSpecifications,
            List<UserList> userLists, List<ProductReview> reviews, List<ShopPrice> shopPrices)
        {
            ID = id;
            Name = name;
            Brand = brand;
            SKU = sku;
            EAN = ean;
            AverageReviewScore = averageReviewScore;
            Price = price;
            Category = category;
            ProductPictures = productPictures;
            ProductSpecifications = productSpecifications;
            UserLists = userLists;
            Reviews = reviews;
            ShopPrices = shopPrices;
        }

        public Product(int id, string name, string brand, string sku, long ean, double averageReviewScore, double price, ProductType productType,
            Category category, List<ProductPicture> productPictures, List<ProductSpecification> productSpecifications,
            List<UserList> userLists, List<ProductReview> reviews, List<ShopPrice> shopPrices)
        {
            ID = id;
            Name = name;
            Brand = brand;
            SKU = sku;
            EAN = ean;
            AverageReviewScore = averageReviewScore;
            Price = price;
            Category = category;
            ProductType = productType;
            ProductPictures = productPictures;
            ProductSpecifications = productSpecifications;
            UserLists = userLists;
            Reviews = reviews;
            ShopPrices = shopPrices;
        }
        #endregion

        #region DatabaseMethods
        public static List<Product> FindAllProductsInCategory(int id)
        {
            List<Product> products = new List<Product>();

            string query = "SELECT * " +
                           "FROM TBL_PRODUCT P " +
                           "INNER JOIN TBL_PRODUCT_CAT PC ON P.ID = PC.PRODUCT_ID " +
                           "INNER JOIN TBL_CATEGORY C ON PC.CATEGORY_ID = C.ID " +
                           "WHERE C.ID=:id";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add(new OracleParameter("id", id));

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dicId = GetProductIdFromDataRecord(reader);
                        if (!Dictionaries.Products.ContainsKey(dicId))
                        {
                            Dictionaries.Products.Add(dicId,
                                GetProductFromDataRecord(reader));
                        }
                        products.Add(Dictionaries.Products[dicId]);
                    }
                }
            }
            return products;
        }

        public static double GetProductAverageReviewScore(int id)
        {
            string query = "SELECT AVG(SCORE) " +
                           "FROM TBL_PRODUCT_REVIEW PR " +
                           "INNER JOIN TBL_REVIEW R ON PR.REVIEW_ID = R.ID " +
                           "INNER JOIN TBL_PRODUCT P ON R.PRODUCT_ID = P.ID " +
                           "WHERE P.ID=:id " +
                           "AND SCORE <= 5";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add(new OracleParameter("id", id));

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            return reader.GetDouble(0);
                        }
                    }
                }
            }
            return 0.00;
        }

        public static double GetProductPrice(int id)
        {
            string query = "SELECT MIN(PRICE) " +
                           "FROM TBL_SHOP_PRODUCT SP " +
                           "INNER JOIN TBL_PRODUCT P ON SP.PRODUCT_ID = P.ID " +
                           "WHERE P.ID=:id";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add(new OracleParameter("id", id));

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            return reader.GetDouble(0);
                        }
                    }
                }
            }
            return 0.00;
        }

        private static Product GetProductFromDataRecord(IDataRecord record)
        {
            int id = Convert.ToInt32(record["ID"]);
            string name = Convert.ToString(record["NAME"]);
            string brand = Convert.ToString(record["BRAND"]);
            string sku = Convert.ToString(record["SKU"]);
            long ean = Convert.ToInt64(record["EAN"]);
            double ars = GetProductAverageReviewScore(Convert.ToInt32(record["ID"]));
            double price = GetProductPrice(Convert.ToInt32(record["ID"]));
            ProductType productType = record.IsDBNull(1) ? null : ProductType.FindById(Convert.ToInt32(record["PRODUCTTYPE_ID"]));
            Category category = Category.FindById(Convert.ToInt32(record["CATEGORY_ID"]));
            List<ProductPicture> productPictures = ProductPicture.FindAllProductPicturesForProduct(id);
            List<ProductSpecification> productSpecifications = ProductSpecification.FindAllSpecs(id);
            List<UserList> userLists = UserList.AllUserListsWithProduct(id);
            List<ProductReview> reviews = ProductReview.AllProductReviews(id);
            List<ShopPrice> shopPrices = ShopPrice.AllShopPriceOfProduct(id);

            if (productType == null)
            {
                return new Product(id, name, brand, sku, ean, ars, price, category,
                    productPictures, productSpecifications, userLists, reviews, shopPrices);
            }

            return new Product(id, name, brand, sku, ean, ars, price, productType,
                category, productPictures, productSpecifications, userLists, reviews, shopPrices);
        }

        private static int GetProductIdFromDataRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["ID"]);
        }
        #endregion
    }
}