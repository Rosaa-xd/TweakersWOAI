using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    /// <summary>
    /// Model class for ShopPrice
    /// </summary>
    public class ShopPrice : DbContext
    {
        public Shop Shop { get; set; }
        public Product Product { get; set; }
        public double Price { get; set; }
        public string ProductURL { get; set; }

        #region Constructors
        /// <summary>
        /// Constructor for getting a ShopPrice out of the database
        /// </summary>
        /// <param name="shop"></param>
        /// <param name="price"></param>
        /// <param name="productURL"></param>
        public ShopPrice(Shop shop, double price, string productURL)
        {
            Shop = shop;
            Price = price;
            ProductURL = productURL;
        }
        #endregion

        #region DatabaseMethods
        /// <summary>
        /// Databasemethod for getting all ShopPrices of a certain product
        /// Put all new ShopPrices in the directory and returns a list of ShopPrices
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<ShopPrice> AllShopPriceOfProduct(int id)
        {
            List<ShopPrice> shopPrices = new List<ShopPrice>();

            string query = "SELECT * " +
                           "FROM TBL_SHOP_PRODUCT " +
                           "WHERE PRODUCT_ID=:id";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add(new OracleParameter("id", id));

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dicId = GetShopPriceIdFromRecord(reader);
                        if (!Dictionaries.ShopPrices.ContainsKey(dicId))
                        {
                            Dictionaries.ShopPrices.Add(dicId,
                                GetShopPriceDataFromRecord(reader));
                        }
                        shopPrices.Add(Dictionaries.ShopPrices[dicId]);
                    }
                }
            }
            return shopPrices;
        }

        /// <summary>
        /// Databasemethod that returns a ShopPrice instance from the database
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private static ShopPrice GetShopPriceDataFromRecord(IDataRecord record)
        {
            return new ShopPrice(
                Shop.FindById(Convert.ToInt32(record["SHOP_ID"])),
                Convert.ToDouble(record["PRICE"]),
                Convert.ToString(record["WEBLINK"]));
        }

        /// <summary>
        /// ShopPrice has a composite primary key in the database with SHOP_ID and PRODUCT_ID as its parameters.
        /// Therefore the combination of SHOP_ID and PRODUCT_ID is always unique and usable as key for the dictionary
        /// </summary>
        /// <param name="record"></param>
        /// <returns>SHOP_ID+PRODUCT_ID</returns>
        private static int GetShopPriceIdFromRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["SHOP_ID"]) + Convert.ToInt32(record["PRODUCT_ID"]);
        }
        #endregion
    }
}