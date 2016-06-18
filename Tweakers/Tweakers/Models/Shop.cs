using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    /// <summary>
    /// Model class for Shop
    /// </summary>
    public class Shop : DbContext
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ShopPrice> ShopPrices;

        #region Constructors
        /// <summary>
        /// Constructor for getting a Shop out of the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Shop(int id, string name)
        {
            ID = id;
            Name = name;
        }
        #endregion

        #region DatabaseMethods
        /// <summary>
        /// Databasemethod for finding a shop by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Shop FindById(int id)
        {
            string query = "SELECT * " +
                           "FROM TBL_SHOP " +
                           "WHERE ID=:id";

            using (OracleConnection connection = CreateConnection())
            using (OracleCommand command = new OracleCommand(query, connection))
            {
                command.BindByName = true;
                command.Parameters.Add(new OracleParameter("id", id));

                using (OracleDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dicId = GetShopIdFromDataRecord(reader);
                        if (!Dictionaries.Shops.ContainsKey(dicId))
                        {
                            Dictionaries.Shops.Add(dicId, GetShopDataFromRecord(reader));
                        }
                        return Dictionaries.Shops[dicId];
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Databasemethod that returns a Shop instance from the database.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private static Shop GetShopDataFromRecord(IDataRecord record)
        {
            return new Shop(
                Convert.ToInt32(record["ID"]),
                Convert.ToString(record["NAME"]));
        }

        /// <summary>
        /// Databasemethod that returns the Shop_ID from a Datarecord.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private static int GetShopIdFromDataRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["ID"]);
        }
        #endregion
    }
}