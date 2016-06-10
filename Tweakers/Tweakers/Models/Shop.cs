using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    public class Shop : DbContext
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ShopPrice> ShopPrices;

        #region Constructors
        public Shop(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public Shop(string name)
        {
            Name = name;
        }

        public Shop(string name, List<ShopPrice> shopPrices)
        {
            Name = name;
            ShopPrices = shopPrices;
        }
        #endregion

        #region DatabaseMethods

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

        private static Shop GetShopDataFromRecord(IDataRecord record)
        {
            return new Shop(
                Convert.ToInt32(record["ID"]),
                Convert.ToString(record["NAME"]));
        }

        private static int GetShopIdFromDataRecord(IDataRecord record)
        {
            return Convert.ToInt32(record["ID"]);
        }
        #endregion
    }
}