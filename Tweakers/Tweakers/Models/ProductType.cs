using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;

namespace Tweakers.Models
{
    public class ProductType : DbContext
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Product> Products;

        #region Constructor
        public ProductType(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public ProductType(string name)
        {
            Name = name;
        }

        public ProductType(string name, List<Product> products)
        {
            Name = name;
            Products = products;
        }
        #endregion

        #region DatabaseMethods

        public static ProductType FindById(int id)
        {
            string query = "SELECT * " +
                           "FROM TBL_PRODUCTTYPE " +
                           "WHERE ID=:id";

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
                            return GetProductTypeFromDataRecord(reader);
                        }
                    }
                }
            }
            return null;
        }

        private static ProductType GetProductTypeFromDataRecord(IDataRecord record)
        {
            return new ProductType(
                Convert.ToInt32(record["ID"]),
                Convert.ToString(record["NAME"]));
        }

        #endregion
    }
}